using mShed.Game.Snap.Cards;
using mShed.Game.Snap.Players;
using Xunit;

namespace mShed.Game.Snap.Tests.KidsGameProvider
{
    public class KidsGameProviderUnitTest
    {
        [Fact]
        public void Valid_snap_when_two_cards_of_the_same_rank_are_on_top_of_pile()
        {
            var player1 = new Player("Player1", 1);
            var player2 = new Player("Player2", 2);
            var gameProvider = new KidsGameBuilder()
                .RegisterPlayer(player1)
                .RegisterPlayer(player2)
                .AddCard(CardSuitType.Clubs, CardRankType.Two)
                .AddCard(CardSuitType.Diamonds, CardRankType.Two)
                .TakeTurn(player1)
                .TakeTurn(player2)
                .Build();

            var isSnap = gameProvider.HandleSnap(new[] { player1 });

            Assert.True(isSnap);
        }

        [Fact]
        public void Invalid_snap_when_two_cards_of_different_rank_are_on_top_of_pile()
        {
            var player1 = new Player("Player1", 1);
            var player2 = new Player("Player2", 2);
            var gameProvider = new KidsGameBuilder()
                .RegisterPlayer(player1)
                .RegisterPlayer(player2)
                .AddCard(CardSuitType.Clubs, CardRankType.Two)
                .AddCard(CardSuitType.Diamonds, CardRankType.Ace)
                .TakeTurn(player1)
                .TakeTurn(player2)
                .Build();

            var isSnap = gameProvider.HandleSnap(new[] { player1 });

            Assert.False(isSnap);
        }

        [Fact]
        public void Take_turn_moves_card_from_players_hand_to_pile()
        {
            var player1 = new Player("Player1", 1);
            var player2 = new Player("Player2", 2);
            var gameProvider = new KidsGameBuilder()
                .RegisterPlayer(player1)
                .RegisterPlayer(player2)
                .AddCard(CardSuitType.Clubs, CardRankType.Two)
                .AddCard(CardSuitType.Diamonds, CardRankType.Ace)
                .TakeTurn(player1)
                .Build();

            Assert.Equal(1, gameProvider.PileCount());
            Assert.Equal(0, gameProvider.PlayerHandCount(player1));
        }

        [Fact]
        public void Player_left_with_all_cards_wins_game()
        {
            var player1 = new Player("Player1", 1);
            var player2 = new Player("Player2", 2);
            var gameProvider = new KidsGameBuilder()
                .RegisterPlayer(player1)
                .RegisterPlayer(player2)
                .AddCard(CardSuitType.Clubs, CardRankType.Two)
                .AddCard(CardSuitType.Diamonds, CardRankType.Two)
                .TakeTurn(player1)
                .TakeTurn(player2)
                .Build();

            gameProvider.HandleSnap(new[] { player1 });
            var winningPlayer = gameProvider.GameWonCheck();

            Assert.NotNull(winningPlayer);
            Assert.Equal(player1.Id, winningPlayer.Id);
        }
    }
}
