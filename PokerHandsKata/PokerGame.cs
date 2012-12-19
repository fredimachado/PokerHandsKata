using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsKata
{
    public enum Score
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    public class PokerGame
    {
        private const int ACE = 14;

        public static Score GetScore(Hand hand)
        {
            if (isRoyalFlush(hand))
                return Score.RoyalFlush;

            if (isStraightFlush(hand))
                return Score.StraightFlush;

            if (isFourOfAKind(hand))
                return Score.FourOfAKind;

            if (isFullHouse(hand))
                return Score.FullHouse;

            if (isFlush(hand))
                return Score.Flush;

            if (isStraight(hand))
                return Score.Straight;

            if (isThreeOfAKind(hand))
                return Score.ThreeOfAKind;

            if (isTwoPair(hand))
                return Score.TwoPair;

            if (isPair(hand))
                return Score.Pair;

            return Score.HighCard;
        }

        private static bool isRoyalFlush(Hand hand)
        {
            return isStraightFlush(hand) && orderedNumbers(hand).Last() == ACE;
        }

        private static bool isStraightFlush(Hand hand)
        {
            return isStraight(hand) && isFlush(hand);
        }

        private static bool isFourOfAKind(Hand hand)
        {
            return duplicated(hand).SingleOrDefault(v => v.Count == 4) != null;
        }

        private static bool isFullHouse(Hand hand)
        {
            return isThreeOfAKind(hand) && isPair(hand);
        }

        private static bool isFlush(Hand hand)
        {
            return hand.Cards
                       .Select(c => c.Suit)
                       .GroupBy(s => s)
                       .Count() == 1;
        }

        private static bool isStraight(Hand hand)
        {
            var ordered = orderedNumbers(hand);
            if (Enumerable.SequenceEqual(ordered, Enumerable.Range(ordered[0], 5)))
                return true;
            return isLowestStraight(ordered);
        }

        private static bool isLowestStraight(int[] ordered)
        {
            if (!isThereExactlyOneAce(ordered))
                return false;
            replaceAceWithOne(ordered);
            return Enumerable.SequenceEqual(ordered.OrderBy(v => v), Enumerable.Range(1, 5));
        }

        private static void replaceAceWithOne(int[] ordered)
        {
            ordered[Array.IndexOf(ordered, ACE)] = 1;
        }

        private static bool isThereExactlyOneAce(int[] ordered)
        {
            return ordered.Where(v => v == ACE).Count() == 1;
        }

        private static bool isThreeOfAKind(Hand hand)
        {
            var values = duplicated(hand);
            return values.Length > 0 && values.SingleOrDefault(v => v.Count == 3) != null;
        }

        private static bool isTwoPair(Hand hand)
        {
            var values = duplicated(hand);
            return values.Length == 2 && values.All(v => v.Count == 2);
        }

        private static bool isPair(Hand hand)
        {
            var values = duplicated(hand);
            return values.Length > 0 && values.SingleOrDefault(v => v.Count == 2) != null;
        }

        private static GroupResult[] duplicated(Hand hand)
        {
            return hand.Cards
                       .Select(c => c.NumberValue)
                       .OrderByDescending(n => n)
                       .GroupBy(n => n)
                       .Where(g => g.Count() > 1)
                       .Select(g => new GroupResult { Value = g.Key, Count = g.Count() })
                       .ToArray();
        }

        private static int[] orderedNumbers(Hand hand)
        {
            return hand.Cards
                       .Select(c => c.NumberValue)
                       .OrderBy(n => n)
                       .ToArray();
        }

        class GroupResult
        {
            public int Value { get; set; }
            public int Count { get; set; }
        }
    }
}
