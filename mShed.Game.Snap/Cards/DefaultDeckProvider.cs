using System;
using System.Collections.Generic;
using System.Linq;

namespace mShed.Game.Snap.Cards
{
    /// <summary>
    /// Default deck provider
    /// </summary>
    public class DefaultDeckProvider : IDeckProvider
    {
        public Queue<ICard> GetShuffledDeck()
        {
            var shuffledDeck = new Queue<ICard>();

            var newDeck = GetNewDeck().ToList();

            var rnd = new Random();
            while (newDeck.Any())
            {
                var selectedIndex = rnd.Next(1, newDeck.Count);
                var card = newDeck[selectedIndex - 1];
                shuffledDeck.Enqueue(card);
                newDeck.Remove(card);
            }

            return shuffledDeck;
        }

        public virtual IEnumerable<ICard> GetNewDeck()
        {
            var newDeck = new List<ICard>();

            foreach (var suit in Enum.GetValues<CardSuitType>())
            {
                foreach (var rank in Enum.GetValues<CardRankType>())
                {
                    newDeck.Add(new Card(suit, rank));
                }
            }

            return newDeck;
        }
    }
}
