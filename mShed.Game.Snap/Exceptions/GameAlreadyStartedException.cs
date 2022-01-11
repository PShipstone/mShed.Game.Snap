using System;

namespace mShed.Game.Snap.Exceptions
{
    /// <summary>
    /// thrown when a request to start the game 
    /// is received but it has already started
    /// </summary>
    public class GameAlreadyStartedException : Exception
    {
        public GameAlreadyStartedException(string message)
        : base(message) { }
    }
}
