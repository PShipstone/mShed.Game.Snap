using mShed.Game.Snap.Cards;
using mShed.Game.Snap.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mShed.Game.Snap.GameProviders
{
    /// <summary>
    /// Simple kids game provider
    /// </summary>
    public class KidsGameProvider : IGameProvider
    {
        private IDeckProvider _deckProvider;
        private Dictionary<Guid, Queue<ICard>> _hand;
        private IList<ICard> _pile;
        private Dictionary<Guid, IPlayer> _players;

        public KidsGameProvider(IDeckProvider deckProvider)
        {
            _deckProvider = deckProvider;
            _hand = new Dictionary<Guid, Queue<ICard>>();
            _pile = new List<ICard>();
        }

        public void TakeTurn(IPlayer player)
        {
            if (!_hand[player.Id].Any())
            {
                return;
            }

            var card = _hand[player.Id].Dequeue();
            _pile.Add(card);
        }

        public bool HandleSnap(IEnumerable<IPlayer> players)
        {
            if (!IsSnapAvailable() || players.Count() != 1)
            {
                return false;
            }

            var player = players.Single();

            var pile = _pile.ToList();
            var playersHand = _hand[player.Id].ToList();

            pile.Reverse();
            playersHand.AddRange(pile);

            _hand[player.Id] = new Queue<ICard>(playersHand);

            _pile.Clear();

            return true;
        }

        public IPlayer GameWonCheck()
        {
            var playersWithCards = _hand.Where(p => p.Value.Any()).Select(h => h.Key);

            if (playersWithCards.Count() == 1)
            {
                return _players[playersWithCards.First()];
            }

            return null;
        }

        public void DealCards(IEnumerable<IPlayer> players)
        {
            var deck = _deckProvider.GetShuffledDeck();

            var playerNumber = 1;
            while (deck.Any())
            {
                var card = deck.Dequeue();
                var player = players.ToArray()[playerNumber - 1];

                if (!_hand.TryGetValue(player.Id, out var playerHand))
                {
                    playerHand = new Queue<ICard>();
                }

                playerHand.Enqueue(card);
                _hand[player.Id] = playerHand;

                if (++playerNumber > players.Count())
                {
                    playerNumber = 1;
                }
            }

            _players = players.ToDictionary(p => p.Id);
        }

        public int PileCount()
        {
            return _pile.Count;
        }

        public int PlayerHandCount(IPlayer player)
        {
            return _hand[player.Id].Count;
        }

        private bool IsSnapAvailable()
        {
            if (_pile.Count < 2)
            {
                return false;
            }

            var top2Cards = _pile
                .TakeLast(2)
                .ToArray();

            var card1 = top2Cards[0];
            var card2 = top2Cards[1];

            if (card1.CardRank == card2.CardRank)
            {
                return true;
            }

            return false;
        }
    }
}
