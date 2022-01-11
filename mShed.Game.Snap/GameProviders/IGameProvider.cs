using mShed.Game.Snap.Players;
using System.Collections.Generic;

namespace mShed.Game.Snap.GameProviders
{
    public interface IGameProvider
    {
        /// <summary>
        /// Deal the cards
        /// </summary>
        /// <param name="players">List of plays playing the game</param>
        void DealCards(IEnumerable<IPlayer> players);

        /// <summary>
        /// Player takes turn
        /// </summary>
        /// <param name="player">Player to take turn</param>
        void TakeTurn(IPlayer player);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="players">One or more players who shout snap</param>
        /// <returns></returns>
        bool HandleSnap(IEnumerable<IPlayer> players);

        /// <summary>
        /// Number of played cards in the pile
        /// </summary>
        /// <returns></returns>
        int PileCount();

        /// <summary>
        /// Gets the number of cards a player is holding
        /// </summary>
        /// <param name="player">Player to get card count for</param>
        /// <returns>Return number of cards</returns>
        int PlayerHandCount(IPlayer player);

        /// <summary>
        /// Check if the game has been won
        /// </summary>
        /// <returns>The play who has won the game</returns>
        IPlayer GameWonCheck();
    }
}
