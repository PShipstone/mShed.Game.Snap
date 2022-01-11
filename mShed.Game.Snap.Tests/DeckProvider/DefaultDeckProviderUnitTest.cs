using mShed.Game.Snap.Cards;
using System.Linq;
using Xunit;

namespace mShed.Game.Snap.Tests.DeckProvider
{
    public class DefaultDeckProviderUnitTest
    {
        [Fact]
        public void Default_deck_provider_should_return_52_cards()
        {
            var deckProvider = new DefaultDeckProvider();

            var shuffledDeck = deckProvider.GetShuffledDeck();

            Assert.Equal(52, shuffledDeck.Count);
        }

        [Fact]
        public void Default_deck_provider_should_return_a_shuffled_deck_of_cards()
        {
            var deckProvider = new DefaultDeckProvider();

            var newDeck = deckProvider.GetNewDeck();
            var shuffledDeck = deckProvider.GetShuffledDeck().ToList();

            Assert.NotEqual(newDeck, shuffledDeck);
        }
    }
}
