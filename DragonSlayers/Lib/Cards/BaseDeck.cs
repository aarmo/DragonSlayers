using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DragonSlayers.Lib.Cards
{
    public class DragonDeck : BaseDeck
    {
        public DragonDeck()
        {
            LoadCards(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\DragonDeck.txt");
        }
    }

    public class SlayerDeck : BaseDeck
    {
        public SlayerDeck()
        {
            LoadCards(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\SlayerDeck.txt");
        }
    }

    public class BaseDeck
    {
        public const int MaxHandSize = 7;

        public List<BaseCard> AllCards { get; set; }
        public List<BaseCard> Deck { get; set; }
        public List<BaseCard> Discard { get; set; }

        protected void LoadCards(string path)
        {
            AllCards = new List<BaseCard>();

            var lines = File.ReadAllLines(path);
            foreach (var l in lines)
            {
                // Bite|2|Mouth Attack
                var c = l.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                var count = int.Parse(c[1]);
                for (var i = 0; i < count; i++)
                {
                    AllCards.Add(new BaseCard(c[0], c[2]));
                }
            }

            Deck = new List<BaseCard>(Dice.Shuffle(AllCards.ToArray()));
            Discard = new List<BaseCard>();
        }
        
        public void ShuffleDiscard()
        {
            if (Discard.Count == 0 || Deck.Count > 0) return;

            Deck.AddRange(Dice.Shuffle(Discard.ToArray()));
            Discard.Clear();
        }

        public List<BaseCard> DrawFromDeck(int num, List<BaseCard> hand, Func<bool> discardExtraCards)
        {
            var list = new List<BaseCard>(Dice.Random(Deck, num));
            if (list.Count < num)
            {
                ShuffleDiscard();
                list.AddRange(Dice.Random(Deck, num - list.Count));
            }
            Deck.RemoveAll(list.Contains);
            hand.AddRange(list);

            if (hand.Count > MaxHandSize) discardExtraCards();

            return list;
        }

        public void DiscardCard(BaseCard card, List<BaseCard> hand)
        {
            Discard.Add(card);
            hand.Remove(card);
        }
    }
}