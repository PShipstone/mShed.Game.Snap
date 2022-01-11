using System;

namespace mShed.Game.Snap.Exceptions
{
    /// <summary>
    /// Thrown when there are too many players
    /// </summary>
    public class TooManyPlayersException : Exception
    {
        public TooManyPlayersException(string message)
        : base(message) { }
    }
}
