using DragonSlayers.Lib.Cards;
using DragonSlayers.Lib.Names;
using System.Collections.Generic;
using System;

namespace DragonSlayers.Lib
{
    public class DragonPlayer : BasePlayer
    {
        public const int MaxHealth = 10;

        // The Dragon has 10 hit points.
        // Unblocked attacks by Slayers cause 1 or more hit points of damage to the Dragon.
        public int HitPoints { get; set; }
        public string Name { get; set; }

        public DragonPlayer(DragonDeck deck)
        {
            var g = (Dice.HalfChance() ? EGender.Male : EGender.Female);
            var n = (Dice.HalfChance() ? Dragon.Generate(g) : DragonBorn.Generate(g));
            Name = n;

            Deck = deck;
            HitPoints = 10;
            Hand = new List<BaseCard>();
        }

        internal void DamageDragon(BaseCard playCard, SlayerRecruit playMember)
        {
            throw new NotImplementedException();
        }
    }
}