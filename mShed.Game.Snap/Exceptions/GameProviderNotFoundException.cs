using System;

namespace mShed.Game.Snap.Exceptions
{
    /// <summary>
    /// thrown when game provider not found
    /// </summary>
    public class GameProviderNotFoundException : Exception
    {
        public GameProviderNotFoundException(string message)
        : base(message) { }
    }
}
