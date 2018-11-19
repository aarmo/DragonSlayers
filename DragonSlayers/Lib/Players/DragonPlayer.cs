using DragonSlayers.Lib.Cards;
using DragonSlayers.Lib.Controllers;
using DragonSlayers.Lib.Logic;
using DragonSlayers.Lib.Names;
using System.Collections.Generic;

namespace DragonSlayers.Lib.Players
{
    public class DragonPlayer : BasePlayer
    {
        public const int MaxHealth = 10;
        public IDragonGameController Controller { get; private set; }

        // The Dragon has 10 hit points.
        // Unblocked attacks by Slayers cause 1 or more hit points of damage to the Dragon.
        public int HitPoints { get; set; }
        public string Name { get; set; }

        public DragonPlayer(DragonDeck deck, IDragonGameController controller)
        {
            var g = (Dice.HalfChance() ? EGender.Male : EGender.Female);
            var n = (Dice.HalfChance() ? Dragon.Generate(g) : DragonBorn.Generate(g));
            Name = n;

            Deck = deck;
            HitPoints = 10;
            Hand = new List<BaseCard>();
        }

        public void DamageDragon(BaseCard playCard, SlayerRecruit playMember)
        {
            var damage = 1;

            if (playMember.Type == ERecruitType.Warrior) damage++;
            if (playMember.Artifact != null) damage += playMember.Artifact.GetDamageBonus();

            HitPoints -= damage;
        }
    }
}