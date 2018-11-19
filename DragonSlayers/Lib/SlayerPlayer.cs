using DragonSlayers.Lib.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DragonSlayers.Lib
{
    public class SlayerPlayer : BasePlayer
    {
        // Party Members (Slayers: Heroes & Men-at-Arms) have 1 hit point each.
        // Each unblocked attack by the Dragon will kill one party member.
        public List<SlayerRecruit> Party { get; set; }
        public List<SlayerRecruit> Dead { get; set; }
        public List<SlayerArtifact> Artifacts { get; set; }

        public SlayerPlayer(SlayerDeck deck)
        {
            Hand = new List<BaseCard>();
            Party = new List<SlayerRecruit>();
            Artifacts = new List<SlayerArtifact>();
            Deck = deck;
        }
        
        public void DamageParty(BaseCard playCard, SlayerRecruit member)
        {
            if (playCard.Amount > -1) playCard.Amount--;

            // This party member dies :(
            Party.Remove(member);
            Dead.Add(member);
        }

        public void RandomParty()
        {
            Party.Clear();
            Artifacts.Clear();

            for (var i = 0; i < 8; i++)
            {
                switch (Dice.Roll(1, 6))
                {
                    case 1:
                        Party.Add(SlayerRecruit.Wizard());
                        break;

                    case 2:
                        Party.Add(SlayerRecruit.Warrior());
                        break;

                    case 3:
                        Party.Add(SlayerRecruit.Archer());
                        break;

                    case 4:
                        Party.Add(SlayerRecruit.MenAtArms());
                        Party.Add(SlayerRecruit.MenAtArms());
                        break;

                    case 5:
                        Artifacts.Add(SlayerArtifact.RandomArtifact());
                        break;

                    case 6:
                        if (!Party.Any(_ => _.Type == ERecruitType.MenAtArms))
                        {
                            Party.Add(SlayerRecruit.MenAtArms());
                            Party.Add(SlayerRecruit.MenAtArms());
                        }
                        else if (!Party.Any(_ => _.Type == ERecruitType.Warrior))
                        {
                            Party.Add(SlayerRecruit.Warrior());
                        }
                        else
                        {
                            switch(Dice.Roll(1,3))
                            {
                                case 1:
                                    Party.Add(SlayerRecruit.Wizard());
                                    break;
                                case 2:
                                    Party.Add(SlayerRecruit.Archer());
                                    break;
                                default:
                                    Artifacts.Add(SlayerArtifact.RandomArtifact());
                                    break;
                            }
                        }
                        break;

                }
            }
        }

        public void RandomPresetParty()
        {
            var n = Dice.Roll(1, 12);

            var m = GetType().GetMethod($"PresetParty{n}");
            m.Invoke(this, new object[] { });
        }

        #region Presets

        public void PresetParty1()
        {
            // Pure Brawn
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Wizard());
        }

        public void PresetParty2()
        {
            // Swords & Arrows
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Archer());

            Artifacts.Add(SlayerArtifact.MagicArrows());
            Artifacts.Add(SlayerArtifact.MagicSword());
        }

        public void PresetParty3()
        {
            // Magic Avengers
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());

            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());

            Artifacts.Add(SlayerArtifact.MagicArmour());
            Artifacts.Add(SlayerArtifact.MagicScrolls());
            Artifacts.Add(SlayerArtifact.MagicStaff());
        }

        public void PresetParty4()
        {
            // Balanced
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Archer());

            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());
            
            Artifacts.Add(SlayerArtifact.MagicPotion());
            Artifacts.Add(SlayerArtifact.MagicStaff());
        }

        public void PresetParty5()
        {
            // Offense
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Archer());

            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());

            Artifacts.Add(SlayerArtifact.MagicArrows());
            Artifacts.Add(SlayerArtifact.MagicStaff());
        }

        public void PresetParty6()
        {
            // Rejuvinators
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Warrior());

            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Wizard());

            Artifacts.Add(SlayerArtifact.MagicPotion());
        }

        public void PresetParty7()
        {
            // Magicly Enhanced
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Warrior());
            
            Party.Add(SlayerRecruit.Wizard());

            Artifacts.Add(SlayerArtifact.MagicArmour());
            Artifacts.Add(SlayerArtifact.MagicSword());
            Artifacts.Add(SlayerArtifact.MagicStaff());
            Artifacts.Add(SlayerArtifact.MagicScrolls());
        }

        public void PresetParty8()
        {
            // Symmetry
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Warrior());

            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Archer());

            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());
        }

        public void PresetParty9()
        {
            // Ranged Attacks
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());

            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Archer());
            Party.Add(SlayerRecruit.Archer());

            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());

            Artifacts.Add(SlayerArtifact.MagicArrows());
        }

        public void PresetParty10()
        {
            // Balanced 2
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Warrior());
            Party.Add(SlayerRecruit.Warrior());

            Party.Add(SlayerRecruit.Archer());

            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());
        }

        public void PresetParty11()
        {
            // Nothing Special
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());

            Party.Add(SlayerRecruit.Archer());

            Party.Add(SlayerRecruit.Wizard());
            Party.Add(SlayerRecruit.Wizard());

            Artifacts.Add(SlayerArtifact.MagicStaff());
            Artifacts.Add(SlayerArtifact.MagicScrolls());
        }

        public void PresetParty12()
        {
            // Sword Force!
            Party.Clear();
            Artifacts.Clear();

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.MenAtArms());
            Party.Add(SlayerRecruit.MenAtArms());

            Party.Add(SlayerRecruit.Warrior());
            
            Party.Add(SlayerRecruit.Wizard());

            Artifacts.Add(SlayerArtifact.MagicArmour());
            Artifacts.Add(SlayerArtifact.MagicSword());
            Artifacts.Add(SlayerArtifact.MagicPotion());
        }

        #endregion
    }

}