using Moq;
using mShed.Game.Snap.Cards;
using mShed.Game.Snap.GameProviders;
using mShed.Game.Snap.Players;
using System.Collections.Generic;

namespace mShed.Game.Snap.Tests.KidsGameProvider
{
    internal class KidsGameBuilder
    {
        public List<ICard> _cards = new List<ICard>();
        private List<IPlayer> _players = new List<IPlayer>();
        private Queue<IPlayer> _takeTurn = new Queue<IPlayer>();

        public IGameProvider Build()
        {
            var mockDeckProvider = new Mock<DefaultDeckProvider>();

            mockDeckProvider.Setup(m => m.GetNewDeck())
                .Returns(_cards);

            var kidsGameProvider = new GameProviders.KidsGameProvider(mockDeckProvider.Object);

            kidsGameProvider.DealCards(_players);

            while (_takeTurn.TryDequeue(out var player))
            {
                kidsGameProvider.TakeTurn(player);
            }

            return kidsGameProvider;
        }

        public KidsGameBuilder AddCard(CardSuitType cardSuit, CardRankType cardRank)
        {
            _cards.Add(new Card(cardSuit, cardRank));
            return this;
        }

        public KidsGameBuilder RegisterPlayer(IPlayer player)
        {
            _players.Add(player);

            return this;
        }

        public KidsGameBuilder TakeTurn(IPlayer player)
        {
            _takeTurn.Enqueue(player);
            return this;
        }
    }
}
