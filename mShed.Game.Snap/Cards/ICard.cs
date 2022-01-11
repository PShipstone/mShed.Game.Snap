namespace mShed.Game.Snap.Cards
{
    public interface ICard
    {
        /// <summary>
        /// Card suite, e.g. Diamonds, Clubs
        /// </summary>
        CardSuitType CardSuit { get; }

        /// <summary>
        /// Card Rant, e.g. Two, Jack, Ace
        /// </summary>
        CardRankType CardRank { get; }
    }
}
