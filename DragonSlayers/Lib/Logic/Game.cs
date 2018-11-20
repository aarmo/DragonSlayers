using System;
using DragonSlayers.Lib.Cards;
using System.Linq;
using System.Collections.Generic;
using DragonSlayers.Lib.Players;
using DragonSlayers.Lib.Controllers;

namespace DragonSlayers.Lib.Logic
{
    /// <summary>
    /// Rules from: http://www.angelfire.com/games2/warpspawn/DSlay.html
    /// </summary>
    public class Game
    {
        public const int NormalDrawNumber = 3;
        public const int ReducedDrawNumber = 1;

        public DragonDeck DragonDeck { get; private set; }
        public SlayerDeck SlayerDeck { get; private set; }
        public DragonPlayer Dragon { get; private set; }
        public SlayerPlayer Slayer { get; private set; }

        private bool _dragonCanAttackAnyHero = false;
        private bool _slayerDrawsLess = false;
        private bool _dragonDrawsLess = false;

        public Game(IDragonGameController dragonPlayer, ISlayerGameController slayerPlayer)
        {
            DragonDeck = new DragonDeck();
            SlayerDeck = new SlayerDeck();

            Dragon = new DragonPlayer(DragonDeck, dragonPlayer);
            Slayer = new SlayerPlayer(SlayerDeck, slayerPlayer);
            Slayer.RandomPresetParty();
        }

        public void Turn()
        {
            DrawCards();
            PlaySlayer();
            PlayDragon();
        }

        private void DrawCards()
        {
            /* DRAW PHASE
                The Slayer player draws 3 cards from the Slayer Deck.
                The Dragon player draws 3 cards from the Dragon Deck.
                If a deck runs out shuffle the discard and draw from it.
                Maximum hand size is 7 cards. Discard excess cards.
            */

            SlayerDeck.DrawFromDeck(_slayerDrawsLess ? ReducedDrawNumber : NormalDrawNumber, Slayer.Hand, DiscardExtraSlayer);
            SlayerCheckArtifacts();

            DragonDeck.DrawFromDeck(_dragonDrawsLess ? ReducedDrawNumber : NormalDrawNumber, Dragon.Hand, DiscardExtraDragon);
        }

        private void PlaySlayer()
        {
            /* SLAYER PHASE
                The party may attack the Dragon.
                To make an attack, an attack card must be discarded from the players hand.
                The party may make multiple attacks.
                There must also be one party member alive who can make the attack.
                For example:  To make a spell attack the party must have at least one Wizard.
                Both Warriors & Men-at-Arms may make Sword Attacks.
                A party member may make only one attack per turn.
                For example:  If you have 2 Wizards you could make 2 spell attacks per turn.
                Each attack does a base of 1 point of damage to the Dragon.
                Some cards indicate they do a base 2 points of damage.
                Warriors inflict an additional point of damage when they attack.
                Some artifacts increase the amount of damage done by an attack.
                The Dragon player may block an attack by discarding a Blocking 
                Card that targets the attack type.
                For example: The Dragon player may discard a ‘Magic Resistance’ card to 
                negate a spell attack.
            */

            BaseCard playCard;

            do
            {
                GameMessage("Please choose a card to play...");
                playCard = GetSlayerPlayCard();
                var usedMembers = new List<SlayerRecruit>();

                if (playCard == null)
                {
                    GameMessage("Ok, your turn is over.");
                    break;
                }

                switch (playCard.CardAction)
                {
                    case ECardAction.Attack:
                        var playMember = GetSlayerAttackMember();
                        if (playMember == null)
                        {
                            GameMessage("Sorry, you have to choose a member to attack with! Please try again...");
                            continue;
                        }
                        if (usedMembers.Contains(playMember))
                        {
                            GameMessage("Sorry, you've already attacked with that member! Please choose again...");
                            continue;
                        }

                        if (!playMember.CanAttackWith(playCard))
                        {
                            GameMessage("Sorry, this member can't attack like that! Please choose again...");
                            continue;
                        }

                        usedMembers.Add(playMember);

                        var blockingCard = GetDragonBlockingCard();
                        if (blockingCard == null)
                        {
                            // Damage Applied!
                            Dragon.DamageDragon(playCard, playMember);
                            GameMessage("You successfully attacked the Dragon! Do you want to play another card?");
                        }
                        else
                        {
                            // Damage Blocked!
                            DragonDeck.DiscardCard(blockingCard, Dragon.Hand);
                            GameMessage("Sorry, the Dragon blocked your attack. Do you want to play another card?");
                        }

                        // Magic Scrolls don't discard the attack card
                        if (playMember.Artifact != null && playMember.Artifact.Type == EArtifactType.MagicScrolls)
                            continue;

                        SlayerDeck.DiscardCard(playCard, Slayer.Hand);
                        break;

                    case ECardAction.DiscardToDraw:
                        SlayerDeck.DiscardCard(playCard, Slayer.Hand);
                        SlayerDeck.DrawFromDeck(_slayerDrawsLess ? ReducedDrawNumber : NormalDrawNumber, Slayer.Hand, DiscardExtraSlayer);
                        GameMessage("You have drawn more cards. Do you want to play another card?");
                        break;

                    case ECardAction.EnemyDrawsLess:
                        SlayerDeck.DiscardCard(playCard, Slayer.Hand);
                        _dragonDrawsLess = true;
                        GameMessage("You have hindered the Dragon's next draw. Do you want to play another card?");
                        break;

                    case ECardAction.Regenerate:
                        var reviveMember = GetSlayerReviveMember();

                        if (reviveMember == null)
                        {
                            GameMessage("No party members revived. Do you want to play another card?");
                            continue;
                        }

                        if (Slayer.Dead.Count > 0)
                        {
                            SlayerDeck.DiscardCard(playCard, Slayer.Hand);
                            Slayer.Dead.Remove(reviveMember);
                            Slayer.Party.Add(reviveMember);
                            GameMessage("You have revived a party member. Do you want to play another card?");
                        }
                        else
                        {
                            GameMessage("You have no party members to revive! Do you want to play another card?");
                        }
                        break;
                }

                if (Dragon.HitPoints <= 0)
                {
                    // YOU WIN!
                    GameMessage("Well done, you have defeated the Dragon!");
                    GameOver(Slayer);
                }


            } while (playCard != null);
        }

        private void PlayDragon()
        {
            /* DRAGON PHASE
                The Dragon may attack the party.
                To make an attack, an attack card must be discarded from the players hand.
                The Dragon may make multiple attacks.
                The Dragon may only use one attack type once per turn.
                For example: The Dragon may not make 2 Firebreath attacks in one turn.
                The Dragon may only use one body part to make one attack type once per turn.
                For example: The Bite and Firebreath attacks are both ‘Mouth’ attacks so 
                only one may be used.
                The Slayer player may block an attack by discarding a Blocking Card that 
                matches the target type.
                For example: The Slayer may discard a ‘Shield’ card to negate an attack vs a 
                Warrior or a Man-at-Arms.
                Each attack targets one party member.
                Dragons must attack Men-at-Arms first.
                After all the Men-at-Arms are killed the Dragon may attack Warriors next.
                After all the Warriors are killed the Dragon may attack Archers & Wizards.
            */

            var typesPlayed = new List<EAttackType>();
            BaseCard playCard;
            SlayerRecruit playTarget;

            do
            {
                GameMessage("Please choose a card to play...");
                playCard = GetDragonPlayCard();

                if (playCard == null)
                {
                    GameMessage("Ok, your turn is over.");
                    break;
                }

                switch (playCard.CardAction)
                {
                    case ECardAction.Attack:
                        if (typesPlayed.Contains(playCard.AttackType))
                        {
                            GameMessage("Sorry, you've already attacked with that type! Please choose again...");
                            continue;
                        }

                        typesPlayed.Add(playCard.AttackType);
                        playTarget = GetDragonAttackTarget();

                        if (playTarget == null)
                        {
                            GameMessage("Sorry, you have to choose a target for that attack! Please try again...");
                            continue;
                        }

                        if (!_dragonCanAttackAnyHero && playTarget.Type != ERecruitType.MenAtArms && Slayer.Party.Any(_ => _.Type == ERecruitType.MenAtArms))
                        {
                            GameMessage("Wait, you must first attack a Man-at-Arms target while they are up! Please try again...");
                            continue;
                        }

                        if (!_dragonCanAttackAnyHero && playTarget.Type != ERecruitType.Warrior && Slayer.Party.Any(_ => _.Type == ERecruitType.Warrior))
                        {
                            GameMessage("Wait, you must first attack a Warrior target while they are up! Please try again...");
                            continue;
                        }

                        var blockingCard = GetSlayerBlockingCard();
                        if (blockingCard == null)
                        {
                            if (!playTarget.Artifact.DamageReduced())
                            {
                                // Damage Applied!
                                Slayer.DamageParty(playCard, playTarget);
                                GameMessage("You successfully attacked the Slayer's party! Do you want to play another card?");
                            }
                            else
                            {
                                GameMessage("Sorry, the Slayer blocked your attack. Do you want to play another card?");
                            }
                        }
                        else
                        {
                            // Damage Blocked!
                            SlayerDeck.DiscardCard(blockingCard, Slayer.Hand);
                            GameMessage("Sorry, the Slayer blocked your attack. Do you want to play another card?");
                        }
                        _dragonCanAttackAnyHero = false;
                        DragonDeck.DiscardCard(playCard, Dragon.Hand);
                        break;

                    case ECardAction.DiscardToDraw:
                        DragonDeck.DiscardCard(playCard, Dragon.Hand);
                        DragonDeck.DrawFromDeck(_dragonDrawsLess ? ReducedDrawNumber : NormalDrawNumber, Dragon.Hand, DiscardExtraDragon);
                        GameMessage("You have drawn more cards. Do you want to play another card?");
                        break;

                    case ECardAction.AttackAnyHero:
                        DragonDeck.DiscardCard(playCard, Dragon.Hand);
                        _dragonCanAttackAnyHero = true;
                        GameMessage("You can now attack any hero! Do you want to play another card?");
                        break;

                    case ECardAction.EnemyDrawsLess:
                        DragonDeck.DiscardCard(playCard, Dragon.Hand);
                        _slayerDrawsLess = true;
                        GameMessage("You have hindered the Slayer's next draw. Do you want to play another card?");
                        break;

                    case ECardAction.Regenerate:
                        if (Dragon.HitPoints < DragonPlayer.MaxHealth)
                        {
                            DragonDeck.DiscardCard(playCard, Dragon.Hand);
                            Dragon.HitPoints++;
                            GameMessage("You have regenerated some health. Do you want to play another card?");
                        }
                        else
                        {
                            GameMessage("You are already at max health! Do you want to play another card?");
                        }
                        break;
                }

                if (Slayer.Party.Count == 0)
                {
                    // YOU WIN!
                    GameMessage("Well done, you have defeated the Slayer's party!");
                    GameOver(Dragon);
                }


            } while (playCard != null);

        }

        private void SlayerCheckArtifacts()
        {
            // If the slayer needs to assign any artifacts:
            foreach (var a in Slayer.Artifacts.Where(_ => _.HeldBy != null))
            {
                var m = GetSlayerMemberForArtifact(a);
                if (m == null) break;
                if (m.Artifact != null)
                {
                    GameMessage("Sorry, that member is already carrying an artifact! Please try again...");
                    continue;
                }
                if (!m.Artifact.UsableBy.Contains(m.Type))
                {
                    GameMessage("Sorry, that member can't use that type of artifact! Please try again...");
                    continue;
                }

                // Store the reference;
                a.HeldBy = m;
                m.Artifact = a;
            }

            // If needed, the slayer's team can pick up an artifact from a dead member
            if (Slayer.Dead.Count > 0)
            {
                foreach (var d in Slayer.Dead.Where(_ => _.Artifact != null))
                {
                    var m = GetSlayerMemberForArtifact(d);
                    if (m == null) break;
                    if (m.Artifact != null)
                    {
                        GameMessage("Sorry, that member is already carrying an artifact! Please try again...");
                        continue;
                    }
                    if (!m.Artifact.UsableBy.Contains(m.Type))
                    {
                        GameMessage("Sorry, that member can't use that type of artifact! Please try again...");
                        continue;
                    }

                    // Move the reference;
                    m.Artifact = d.Artifact;
                    d.Artifact = null;
                }
            }
        }

        private SlayerRecruit GetSlayerMemberForArtifact(SlayerRecruit d)
        {
            // TODO: Call the method in the UI/AI to get the new member to move this artifact to
            throw new NotImplementedException();
        }

        private SlayerRecruit GetSlayerMemberForArtifact(SlayerArtifact d)
        {
            // TODO: Call the method in the UI/AI to get the member to assign this artifact to
            throw new NotImplementedException();
        }

        private BaseCard GetDragonBlockingCard()
        {
            // TODO: Call the method in the other player's UI/AI to get a card to block with
            throw new NotImplementedException();
        }

        private SlayerRecruit GetSlayerAttackMember()
        {
            // TODO: Call the method in the UI/AI to get the member to attack with
            throw new NotImplementedException();
        }

        private SlayerRecruit GetSlayerReviveMember()
        {
            // TODO: Call the method in the UI/AI to get the member to revive
            throw new NotImplementedException();
        }

        private BaseCard GetSlayerPlayCard()
        {
            // TODO: Call the method in the UI/AI to get the card to play
            throw new NotImplementedException();
        }

        private void GameOver(BasePlayer winningPlayer)
        {
            // TODO: Call the method in both player's UI - the game is over!
            throw new NotImplementedException();
        }

        private BaseCard GetSlayerBlockingCard()
        {
            // TODO: Call the method in the other player's UI/AI to get the card to play
            throw new NotImplementedException();
        }

        private SlayerRecruit GetDragonAttackTarget()
        {
            // TODO: Call the method in the UI/AI to get the target
            throw new NotImplementedException();
        }

        private BaseCard GetDragonPlayCard()
        {
            // TODO: Call the method in the UI/AI to get the card to play
            throw new NotImplementedException();
        }

        private void GameMessage(string message, bool bothPlayers = false)
        {
            //TODO: Raise an event to this UI this message
            throw new NotImplementedException();
        }        

        private bool DiscardExtraDragon()
        {
            // TODO: Ask the player to discard extra cards
            throw new NotImplementedException();
        }

        private bool DiscardExtraSlayer()
        {
            // TODO: Ask the player to discard extra cards
            throw new NotImplementedException();
        }
    }
}
