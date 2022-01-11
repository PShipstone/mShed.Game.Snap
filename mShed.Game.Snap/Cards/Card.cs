using System.Diagnostics;

namespace mShed.Game.Snap.Cards
{
    [DebuggerDisplay("{CardSuit} {CardRank}")]
    public class Card : ICard
    {
        public CardSuitType CardSuit { get; }
        public CardRankType CardRank { get; }

        public Card(CardSuitType cardSuit, CardRankType cardRank)
        {
            CardSuit = cardSuit;
            CardRank = cardRank;
        }
    }
}
