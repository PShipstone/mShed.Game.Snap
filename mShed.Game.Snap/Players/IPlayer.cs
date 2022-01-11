using System;

namespace mShed.Game.Snap.Players
{
    public interface IPlayer
    {
        /// <summary>
        /// Player ordinal
        /// </summary>
        int Ordinal { get; }

        /// <summary>
        /// Player unique id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Player name
        /// </summary>
        string Name { get; }
    };
}
