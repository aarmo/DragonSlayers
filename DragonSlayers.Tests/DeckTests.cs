using DragonSlayers.Lib;
using DragonSlayers.Lib.Cards;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace DragonSlayers.Tests
{
    class DeckTests
    {
        [Test]
        public void CheckDragonDeck()
        {
            var d = new DragonDeck();

            d.AllCards.Count.Should().Be(35);
            d.Deck.Count.Should().Be(35);
            d.Discard.Should().BeEmpty();
            d.AllCards.Count(_ => _.CardAction == ECardAction.None).Should().Be(0);
        }

        [Test]
        public void CheckSlayerDeck()
        {
            var d = new SlayerDeck();

            d.AllCards.Count.Should().Be(35);
            d.Deck.Count.Should().Be(35);
            d.Discard.Should().BeEmpty();
            d.AllCards.Count(_ => _.CardAction == ECardAction.None).Should().Be(0);
        }
    }
}
