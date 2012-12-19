using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokerHandsKata.Tests
{
    public class PokerGameTests
    {
        Hand h;

        private void CreateHand(string hand)
        {
            h = new Hand(hand);
        }

        [Fact]
        public void ShouldBeHighCard()
        {
            CreateHand("2H 6S 9S KS JD");
            Assert.Equal(Score.HighCard, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBePair()
        {
            CreateHand("2H 6C 9S 2D JD");
            Assert.Equal(Score.Pair, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeTwoPair()
        {
            CreateHand("2H 6C 2S 6H QD");
            Assert.Equal(Score.TwoPair, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeThreeOfAKind()
        {
            CreateHand("2H 2S 8C QH 2D");
            Assert.Equal(Score.ThreeOfAKind, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeStraight()
        {
            CreateHand("4H 8S 6D 5C 7H");
            Assert.Equal(Score.Straight, PokerGame.GetScore(h));

            CreateHand("AS 5D 4H 2C 3S");
            Assert.Equal(Score.Straight, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeFlush()
        {
            CreateHand("4H 8H AH 5H 2H");
            Assert.Equal(Score.Flush, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeFullHouse()
        {
            CreateHand("4D 9S 9D 4H 4C");
            Assert.Equal(Score.FullHouse, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeFourOfAKind()
        {
            CreateHand("AS AD 9S AC AH");
            Assert.Equal(Score.FourOfAKind, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeStraightFlush()
        {
            CreateHand("9S 10S JS QS KS");
            Assert.Equal(Score.StraightFlush, PokerGame.GetScore(h));
        }

        [Fact]
        public void ShouldBeRoyalFlush()
        {
            CreateHand("10S JS QS KS AS");
            Assert.Equal(Score.RoyalFlush, PokerGame.GetScore(h));
        }
    }
}
