using mShed.Game.Snap.Players;
using System.Collections.Generic;

namespace mShed.Game.Snap
{
    public interface IGame
    {
        /// <summary>
        /// Get game state
        /// </summary>
        GameStateType GameState { get; }

        /// <summary>
        /// Register a new player
        /// </summary>
        /// <param name="name"></param>
        void RegisterPlayer(string name);

        /// <summary>
        /// Get players playing the game
        /// </summary>
        /// <returns></returns>
        IList<IPlayer> GetPlayers();

        /// <summary>
        /// Begin the game of snap
        /// </summary>
        void BeginGame();

        /// <summary>
        /// Check if the game has been won
        /// </summary>
        /// <returns>Player that has won the game, otherwise null</returns>
        IPlayer GameWonCheck();

        /// <summary>
        /// Snap shouted
        /// </summary>
        /// <param name="player">Players who shouted snap</param>
        /// <returns>True if there is a snap, otherwise false</returns>
        bool Snap(IEnumerable<IPlayer> player);

        /// <summary>
        /// Player takes turn
        /// </summary>
        /// <param name="player">Player who is taking a turn</param>
        void TakeTurn(IPlayer player);
    }
}
