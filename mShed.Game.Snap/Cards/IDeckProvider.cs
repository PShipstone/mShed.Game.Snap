using System.Collections.Generic;

namespace mShed.Game.Snap.Cards
{
    public interface IDeckProvider
    {
        /// <summary>
        /// Get a new unshuffled deck of cards
        /// </summary>
        /// <returns>New deck of cards</returns>
        IEnumerable<ICard> GetNewDeck();

        /// <summary>
        /// Get shuffled deck of cards
        /// </summary>
        /// <returns>Shuffled deck of cards</returns>
        Queue<ICard> GetShuffledDeck();
    }
}
