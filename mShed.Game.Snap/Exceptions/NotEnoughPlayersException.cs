using System;

namespace mShed.Game.Snap.Exceptions
{
    /// <summary>
    /// Thrown when there are not enough players
    /// </summary>
    public class NotEnoughPlayersException : Exception
    {
        public NotEnoughPlayersException(string message)
        : base(message) { }
    }
}
