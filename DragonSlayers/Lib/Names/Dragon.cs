namespace DragonSlayers.Lib.Names
{
    /// <summary>
    /// Data from: http://www.fantasynamegenerators.com/dragon_names.php
    /// </summary>
    public class Dragon
    {
        private static string[] nm1 = new[] { "", "", "", "", "b", "br", "c", "ch", "d", "fr", "g", "gr", "j", "k", "m", "n", "p", "q", "r", "t", "x", "z" };
        private static string[] nm2 = new[] { "u", "u", "u", "u", "u", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "ai", "ay", "ei", "eo", "ia", "ie", "oi" };
        private static string[] nm3 = new[] { "d", "ddr", "dr", "g", "gh", "k", "lb", "ldr", "lr", "lzr", "m", "mb", "mm", "mr", "n", "nd", "ndr", "nn", "r", "rd", "rg", "rr", "rs", "rv", "s", "t", "th", "v", "vr", "z", "zz" };
        private static string[] nm4 = new[] { "cr", "d", "n", "nt", "r", "rr", "sd" };
        private static string[] nm5 = new[] { "", "", "d", "g", "m", "n", "nth", "r", "rth", "s", "ss", "t" };

        private static string[] nm6 = new[] { "", "", "", "", "", "", "b", "c", "ch", "d", "f", "fr", "g", "h", "l", "m", "n", "p", "q", "r", "s", "sh", "t", "v", "z" };
        private static string[] nm7 = new[] { "u", "u", "u", "u", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "a", "e", "i", "o", "y", "ae", "ai", "ay", "ei", "eo", "ie", "io", "oa" };
        private static string[] nm8 = new[] { "d", "dh", "g", "gh", "k", "ldr", "ll", "m", "mm", "mr", "n", "nd", "ndr", "nn", "p", "ph", "r", "rg", "rl", "rm", "rr", "rs", "rv", "s", "ss", "t", "th", "v", "vn", "z", "zz" };
        private static string[] nm9 = new[] { "d", "l", "n", "nt", "ph", "r", "rr", "ss" };
        private static string[] nm10 = new[] { "", "", "", "", "", "l", "lth", "n", "nth", "r", "rth", "s", "ss", "t", "th" };

        private static string[] nm11 = new[] { "", "", "", "", "b", "c", "ch", "d", "fr", "g", "m", "n", "p", "q", "r", "s", "t", "v", "x", "z" };
        private static string[] nm12 = new[] { "u", "u", "u", "u", "a", "e", "i", "o", "y", "ae", "ai", "ay", "ei", "eo", "ia", "ie", "io", "oa", "oi" };
        private static string[] nm13 = new[] { "d", "dh", "dr", "g", "gh", "k", "l", "ldr", "ll", "lr", "m", "mm", "mr", "n", "nd", "ndr", "nn", "p", "ph", "r", "rl", "rm", "rr", "rs", "rv", "s", "ss", "t", "th", "v", "vn", "vr", "z", "zz" };
        private static string[] nm14 = new[] { "d", "l", "n", "nt", "ph", "r", "rr", "ss" };
        private static string[] nm15 = new[] { "", "", "", "d", "g", "l", "lth", "n", "nth", "r", "rth", "s", "ss", "t", "th" };

        private static string[] nm16 = new[] { "the Nocturnal", "the Protective", "the Clever", "the Bright", "the Dark", "the Dark One", "the Dark", "the Eternal", "the Firestarter", "the Eternal One", "the Calm", "the Gentle", "the Redeemer", "the Champion", "the Evil One", "the Chosen", "the Great", "the Kind", "the Fierce", "the Strong", "the Tiran", "the Dragonlord", "the Warrior", "the Barbarian", "the Tall", "the Magnificent", "the Clean", "the Adorable", "the Gifted", "the Tender", "the Powerful One", "the Gifted One", "the Powerful", "the Black", "the White", "the White One", "the Careful", "the Clumsy One", "the Grumpy", "the Jealous One", "the Mysterious", "the Mysterious One", "the Scary", "the Scary One", "the Brave", "the Victorious", "the Skinny One", "the Mammoth", "the Puny", "the Quiet", "the Voiceless", "the Loud", "the Voiceless One", "the Fast One", "the Swift", "the Young One", "the Youngling", "the Slow", "the Creep", "the Warm", "Warmheart", "Braveheart", "Gentleheart", "the Strong Minded", "the Stubborn", "Firebreath", "Icebreath", "the Squeeler", "Champion of Dragons", "Eternal Fire", "Gentle Mind", "Longtail", "Redeemer of Men", "Protector of the Weak", "Protector of the Forest", "Protector of the Sky", "Lord of the Skies", "Champion of the Skies", "Champion of Men", "Lord of Fire", "Lord of Ice", "Lord of the Red", "Lord of the Black", "Lord of the White", "Lord of the Blue", "Lord of the Green", "Lord of the Yellow", "Lord of the Brown", "Champion of the Red", "Champion of the White", "Champion of the Black", "Champion of the Blue", "Champion of the Yellow", "Champion of the Brown", "Champion of the Green", "Protector of Creatures", "Protector of Life", "Giver of Life", "Bringer of Death", "the Deathlord", "the Dead", "Destroyer of Life", "Destroyer of Men", "Eater of Sheep", "Eater of All", "the Hungry", "Eater of Bunnies", "the Bunny Killer", "the Rabbit Slayer", "the Taker of Life", "the Insane", "the Life Giver" };

        private static string[] nm17 = new[] { "the Nocturnal", "the Protective", "the Clever", "the Bright", "the Dark", "the Dark One", "the Dark", "the Eternal", "the Firestarter", "the Eternal One", "the Calm", "the Gentle", "the Redeemer", "the Champion", "the Evil One", "the Chosen", "the Great", "the Kind", "the Fierce", "the Strong", "the Tiran", "the Dragonlady", "the Warrior", "the Barbarian", "the Tall", "the Magnificent", "the Clean", "the Adorable", "the Gifted", "the Tender", "the Powerful One", "the Gifted One", "the Powerful", "the Black", "the White", "the White One", "the Careful", "the Clumsy One", "the Grumpy", "the Jealous One", "the Mysterious", "the Mysterious One", "the Scary", "the Scary One", "the Brave", "the Victorious", "the Skinny One", "the Mammoth", "the Puny", "the Quiet", "the Voiceless", "the Loud", "the Voiceless One", "the Fast One", "the Swift", "the Young One", "the Youngling", "the Slow", "the Creep", "the Warm", "Warmheart", "Braveheart", "Gentleheart", "the Strong Minded", "the Stubborn", "Firebreath", "Icebreath", "the Squeeler", "Champion of Dragons", "Eternal Fire", "Gentle Mind", "Longtail", "Redeemer of Men", "Protector of the Weak", "Protector of the Forest", "Protector of the Sky", "Lady of the Skies", "Champion of the Skies", "Champion of Men", "Lady of Fire", "Lady of Ice", "Lady of the Red", "Lady of the Black", "Lady of the White", "Lady of the Blue", "Lady of the Green", "Lady of the Yellow", "Lady of the Brown", "Champion of the Red", "Champion of the White", "Champion of the Black", "Champion of the Blue", "Champion of the Yellow", "Champion of the Brown", "Champion of the Green", "Protector of Creatures", "Protector of Life", "Giver of Life", "Bringer of Death", "the Deathlady", "the Dead", "Destroyer of Life", "Destroyer of Men", "Eater of Sheep", "Eater of All", "the Hungry", "Eater of Bunnies", "the Bunny Killer", "the Rabbit Slayer", "the Taker of Life", "the Insane", "the Life Giver" };

        public static string Generate(EGender gender)
        {

            if (gender == EGender.Male)
            {
                var rnd16 = Dice.Random(nm17);
                var rnd = Dice.Random(nm6);
                var rnd2 = Dice.Random(nm7);
                var rnd3 = Dice.Random(nm8);
                var rnd4 = Dice.Random(nm7);
                var rnd5 = Dice.Random(nm10);

                while (rnd == rnd3)
                {
                    rnd3 = Dice.Random(nm8);
                }
                while (rnd5 == rnd3)
                {
                    rnd5 = Dice.Random(nm10);
                }

                if (Dice.HalfChance())
                {
                    return rnd + rnd2 + rnd3 + rnd4 + rnd5 + ", " + rnd16;
                }
                else
                {
                    var rnd6 = Dice.Random(nm9);
                    var rnd7 = Dice.Random(nm7);
                    while (rnd6 == rnd3)
                    {
                        rnd6 = Dice.Random(nm9);
                    }
                    return rnd + rnd2 + rnd3 + rnd4 + rnd6 + rnd7 + rnd5 + ", " + rnd16;
                }
            }
            else
            {
                var rnd16 = Dice.Random(nm16);
                var rnd = Dice.Random(nm11);
                var rnd2 = Dice.Random(nm12);
                var rnd3 = Dice.Random(nm13);
                var rnd4 = Dice.Random(nm12);
                var rnd5 = Dice.Random(nm15);
                while (rnd == rnd3)
                {
                    rnd3 = Dice.Random(nm13);
                }
                while (rnd5 == rnd3)
                {
                    rnd5 = Dice.Random(nm15);
                }
                if (Dice.HalfChance())
                {
                    return rnd + rnd2 + rnd3 + rnd4 + rnd5 + ", " + rnd16;
                }
                else
                {
                    var rnd6 = Dice.Random(nm14);
                    var rnd7 = Dice.Random(nm12);
                    while (rnd6 == rnd3)
                    {
                        rnd6 = Dice.Random(nm14);
                    }
                    return rnd + rnd2 + rnd3 + rnd4 + rnd6 + rnd7 + rnd5 + ", " + rnd16;
                }
            }
        }
    }
}
