using mShed.Game.Snap.Exceptions;
using mShed.Game.Snap.Players;
using System;
using Xunit;

namespace mShed.Game.Snap.Tests.Game
{
    public class GameUnitTest
    {
        [Fact]
        public void Players_are_able_to_be_registered()
        {
            var game = new GameBuilder()
                .RegisterPlayer("player1")
                .RegisterPlayer("player2")
                .Build();

            Assert.Equal(2, game.GetPlayers().Count);
        }

        [Fact]
        public void Starting_game_with_less_than_2_Players_throws_not_enough_players_exception()
        {
            var game = new GameBuilder()
                .RegisterPlayer("player1")
                .Build();

            Assert.Throws<NotEnoughPlayersException>(() =>
            {
                game.BeginGame();
            });
        }

        [Fact]
        public void Cannot_start_a_game_that_is_already_in_progress_throw_game_already_started_exception()
        {
            var game = new GameBuilder()
                .RegisterPlayer("Player1")
                .RegisterPlayer("Player2")
                .Build();

            game.BeginGame();

            Assert.Throws<GameAlreadyStartedException>(() =>
            {
                game.BeginGame();
            });
        }

        [Fact]
        public void Starting_game_with_more_than_6_Players_throws_too_many_players_exception()
        {
            var game = new GameBuilder()
                .RegisterPlayer("player1")
                .RegisterPlayer("player2")
                .RegisterPlayer("player3")
                .RegisterPlayer("player4")
                .RegisterPlayer("player5")
                .RegisterPlayer("player6")
                .RegisterPlayer("player7")
                .Build();

            Assert.Throws<TooManyPlayersException>(() =>
            {
                game.BeginGame();
            });
        }

        [Fact]
        public void Invalid_game_type_throws_game_provider_not_found_exception()
        {
            Assert.Throws<GameProviderNotFoundException>(() =>
            {
                var game = new GameBuilder()
                    .InvalidGameType()
                    .Build();
            });
        }

        [Fact]
        public void Game_state_is_not_started_when_game_has_not_been_started()
        {
            var game = new GameBuilder()
                .Build();

            Assert.Equal(GameStateType.NotStarted, game.GameState);
        }

        [Fact]
        public void Game_state_is_in_progress_when_game_is_started()
        {
            var game = new GameBuilder()
                .UseStandardGame()
                .RegisterPlayer("player1")
                .RegisterPlayer("player2")
                .Build();

            game.BeginGame();

            Assert.Equal(GameStateType.InProgress, game.GameState);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void One_player_wins_game_of_snap_eventually(int numberOfPlayers)
        {
            var gameBuilder = new GameBuilder()
                .UseStandardGame();

            for (var playerNo = 1; playerNo <= numberOfPlayers; playerNo++)
            {
                gameBuilder.RegisterPlayer($"Player{playerNo}");
            }

            var game = gameBuilder.Build();

            var players = game.GetPlayers();

            game.BeginGame();
            var rnd = new Random();
            IPlayer winningPlayer = null;
            int currentPlayer = 1;
            while (winningPlayer == null)
            {
                var player = players[currentPlayer - 1];
                game.TakeTurn(player);

                var snapPlayer = players[rnd.Next(0, players.Count)];
                game.Snap(new[] { snapPlayer });

                winningPlayer = game.GameWonCheck();

                if (++currentPlayer > players.Count)
                {
                    currentPlayer = 1;
                }
            }

            Assert.NotNull(winningPlayer);
            Assert.Equal(GameStateType.Finished, game.GameState);
        }
    }
}
