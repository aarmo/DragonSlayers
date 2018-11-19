using DragonSlayers.Lib.Cards;
using System.Collections.Generic;

namespace DragonSlayers.Lib
{
    public class BasePlayer
    {
        public List<BaseCard> Hand { get; set; }
        public BaseDeck Deck { get; set; }
    }
}