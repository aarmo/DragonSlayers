using DragonSlayers.Lib;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace DragonSlayers.Tests
{
    public class DiceTests
    {
        [Test]
        public void CheckRoll_4d6()
        {
            var result = Dice.Roll("4d6");

            result.Should().BeInRange(4, 24);
        }

        [Test]
        public void CheckRoll_1d8()
        {
            var result = Dice.Roll("1d8");

            result.Should().BeInRange(1, 8);
        }

        [Test]
        public void CheckRoll_1d20()
        {
            var result = Dice.Roll("1d20");

            result.Should().BeInRange(1, 20);
        }

        [Test]
        public void CheckRoll_10d100()
        {
            var result = Dice.Roll("10d100");

            result.Should().BeInRange(10, 1000);
        }

        [Test]
        public void CheckRoll_List_One()
        {
            var data = new[] { "1", "2", "3", "4", "5", "6" };
            var result = Dice.Random(data);

            data.Should().Contain(result);
        }

        [Test]
        public void CheckRoll_List_Some()
        {
            var data = new[] { "1", "2", "3", "4", "5", "6" };
            var result = Dice.Random(data, 3);

            result.Count().Should().Be(3);
        }

        [Test]
        public void CheckRoll_List_Zero()
        {
            var data = new[] { "1", "2", "3", "4", "5", "6" };
            var result = Dice.Random(data, 0);

            result.Should().BeEmpty();
        }

        [Test]
        public void CheckRoll_List_Negative()
        {
            var data = new[] { "1", "2", "3", "4", "5", "6" };
            var result = Dice.Random(data, -2);

            result.Should().BeEmpty();
        }

        [Test]
        public void CheckRoll_List_Max()
        {
            var data = new[] { "1", "2", "3", "4", "5", "6" };
            var result = Dice.Random(data, 6);

            result.Count().Should().Be(6);
        }

        [Test]
        public void CheckRoll_List_TooMany()
        {
            var data = new[] { "1", "2", "3", "4", "5", "6" };
            var result = Dice.Random(data, 10);

            result.Count().Should().Be(6);
        }

        [Test]
        public void CheckNexts()
        {
            for (var i = 0; i < 100; i++)
            {
                var result = Dice.Random(10);
                result.Should().BeInRange(0, 9);
            }
        }

        [Test]
        public void CheckSimpleRolls()
        {
            for (var i = 0; i < 100; i++)
            {
                var result = Dice.Roll(1, 10);
                result.Should().BeInRange(1, 10);
            }
        }

        [Test]
        public void CheckShuffle()
        {
            var data = new[] { "1", "2", "3", "4", "5", "6" };
            var result = Dice.Shuffle(data);

            data.Should().Contain(result);
        }

        [Test]
        public void CheckShuffle_Single()
        {
            var data = new[] { 0 };
            var result = Dice.Shuffle(data);

            result[0].Should().Be(0);
        }
    }
}
