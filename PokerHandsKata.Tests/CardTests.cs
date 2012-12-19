using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerHandsKata.Tests
{
    public class CardTests
    {
        [Fact]
        public void ShouldReturn6ForNumberValueAndHForSuit()
        {
            Card c = new Card("6H");

            Assert.Equal(6, c.NumberValue);
            Assert.Equal("H", c.Suit);
        }

        [Fact]
        public void ShouldReturn12ForNumberValueAndCForSuit()
        {
            Card c = new Card("QC");

            Assert.Equal(12, c.NumberValue);
            Assert.Equal("C", c.Suit);
        }

        [Fact]
        public void ShouldThrowExceptionOnInvalidCardNumber()
        {
            Assert.Throws<ArgumentException>(() => { Card c = new Card("22H"); });
            Assert.Throws<ArgumentException>(() => { Card c = new Card("0H"); });
            Assert.Throws<ArgumentException>(() => { Card c = new Card("PH"); });
        }

        [Fact]
        public void ShouldThrowExceptionOnInvalidSuit()
        {
            Assert.Throws<ArgumentException>(() => { Card c = new Card("2X"); });
        }

        [Fact]
        public void ShouldThrowExceptionOnInvalidCard()
        {
            Assert.Throws<ArgumentException>(() => { Card c = new Card(""); });
        }

        [Fact]
        public void ShouldReturnTheRightToString()
        {
            Card c = new Card("QC");

            Assert.Equal("QC", c.ToString());
        }
    }
}
