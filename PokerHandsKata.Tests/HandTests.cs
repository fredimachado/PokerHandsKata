using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerHandsKata.Tests
{
    public class HandTests
    {
        [Fact]
        public void ShouldHaveJustOneCard()
        {
            Hand h = new Hand("2H");

            Assert.Equal(1, h.Cards.Length);
            Assert.Equal(2, h.Cards[0].NumberValue);
            Assert.Equal("H", h.Cards[0].Suit);
        }

        [Fact]
        public void ShouldSplitTheStringOfCards()
        {
            Card[] cards = new Hand("2H AS").Cards;

            Assert.Equal(2, cards[0].NumberValue);
            Assert.Equal("H", cards[0].Suit);
            Assert.Equal(14, cards[1].NumberValue);
            Assert.Equal("S", cards[1].Suit);
        }
    }
}
