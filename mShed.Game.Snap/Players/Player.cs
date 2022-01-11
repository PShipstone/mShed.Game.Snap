using System;
using System.Diagnostics;

namespace mShed.Game.Snap.Players
{
    [DebuggerDisplay("Id = {Id}; Name = {Name}")]
    public class Player : IPlayer
    {
        public Guid Id { get; }
        public int Ordinal { get; }
        public string Name { get; }

        public Player(string name, int ordinal)
        {
            Id = Guid.NewGuid();
            Ordinal = ordinal;
            Name = name;
        }
    }
}
