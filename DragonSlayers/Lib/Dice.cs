using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonSlayers.Lib
{
    public class Dice
    {
        private static Random _rnd = new Random();

        public static bool HalfChance()
        {
            return _rnd.Next(2) == 1;
        }

        public static int Random(int max)
        {
            return _rnd.Next(max);
        }

        public static T Random<T>(T[] array)
        {
            return array[_rnd.Next(array.Length)];
        }

        public static T[] Shuffle<T>(T[] array)
        {
            for (int n = array.Length - 1; n > 0; --n)
            {
                int k = _rnd.Next(n + 1);
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return array;
        }

        public static T Random<T>(IEnumerable<T> en)
        {
            var i = _rnd.Next(en.Count());
            return en.Skip(i).FirstOrDefault();
        }

        public static IEnumerable<T> Random<T>(IEnumerable<T> en, int num)
        {
            if (num >= en.Count()) return en;
            if (num <= 0) return new T[0];

            var l1 = new List<T>(en);
            var l2 = new List<T>();

            for (var i = 0; i < num; i++)
            {
                var l = l1[_rnd.Next(l1.Count)];
                l1.Remove(l);
                l2.Add(l);
            }

            return l2;
        }

        public static int Roll(string format)
        {
            var dPos = format.LastIndexOf('d');
            var diceSize = Convert.ToUInt16(format.Substring(dPos + 1));
            var numDice = Convert.ToUInt16(format.Substring(0, dPos));

            return Roll(numDice, diceSize);
        }

        public static int Roll(int num, int size)
        {
            return num * (_rnd.Next(size) + 1);
        }
    }
}
