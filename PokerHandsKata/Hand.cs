using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandsKata
{
    public class Hand
    {
        public readonly Card[] Cards;

        public Hand(string cards)
        {
            Cards = splitCards(cards);
        }

        private Card[] splitCards(string cards)
        {
            return cards.Split(' ')
                        .Select(c => new Card(c))
                        .ToArray();
        }
    }
}
