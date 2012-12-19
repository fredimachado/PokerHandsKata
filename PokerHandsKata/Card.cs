using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokerHandsKata
{
    public class Card
    {
        private static readonly Dictionary<string, int> pictureCards = new Dictionary<string, int>
        {
            { "J", 11 },
            { "Q", 12 },
            { "K", 13 },
            { "A", 14 }
        };

        private static readonly string[] suits = new[] { "C", "S", "H", "D" };

        public readonly string Value;
        public readonly int NumberValue;
        public readonly string Suit;

        public Card(string value)
        {
            var match = Regex.Match(value, @"^(.+)(.)$");

            if (!match.Success)
                throw new ArgumentException(string.Format("Invalid card: {0}", value));

            Value = match.Groups[1].Value;
            Suit = match.Groups[2].Value;

            if (!suits.Contains(Suit))
                throw new ArgumentException(string.Format("Invalid suit: {0}", Suit));

            if (pictureCards.ContainsKey(Value))
                NumberValue = pictureCards[Value];
            else
                Int32.TryParse(Value, out NumberValue);

            if (NumberValue > 14 || NumberValue < 2)
                throw new ArgumentException(string.Format("Invalid card value: {0}", Value));
        }

        public override string ToString()
        {
            return Value + Suit;
        }
    }
}
