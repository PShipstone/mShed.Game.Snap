using mShed.Game.Snap.Cards;
using mShed.Game.Snap.Exceptions;
using mShed.Game.Snap.GameProviders;
using mShed.Game.Snap.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mShed.Game.Snap
{
    public class Game : IGame
    {
        private IGameProvider _gameProvider;
        private Dictionary<Guid, IPlayer> _players;

        public GameStateType GameState { get; private set; }

        public Game(GameType gameType)
        {
            _players = new Dictionary<Guid, IPlayer>();

            switch (gameType)
            {
                case GameType.KidsRules:
                    _gameProvider = new KidsGameProvider(new DefaultDeckProvider());
                    break;
                default:
                    throw new GameProviderNotFoundException(nameof(gameType));
            }
        }

        public void RegisterPlayer(string name)
        {
            var player = new Player(name, _players.Count + 1);
            _players.Add(player.Id, player);
        }

        public void BeginGame()
        {
            if(GameState != GameStateType.NotStarted)
            {
                throw new GameAlreadyStartedException("The game has already started");
            }

            if (_players.Count < 2)
            {
                throw new NotEnoughPlayersException("A minimum of 2 players are required to play Snap");
            }

            if (_players.Count > 6)
            {
                throw new TooManyPlayersException("A maximum of 6 players can play Snap");
            }

            _gameProvider.DealCards(_players.Values.ToArray());

            GameState = GameStateType.InProgress;
        }

        public void TakeTurn(IPlayer player)
        {
            _gameProvider.TakeTurn(player);
        }

        public bool Snap(IEnumerable<IPlayer> player)
        {
            var isSnap = _gameProvider.HandleSnap(player);

            return isSnap;
        }

        public IPlayer GameWonCheck()
        {
            var winningPlayer = _gameProvider.GameWonCheck();

            if(winningPlayer != null)
            {
                GameState = GameStateType.Finished;
            }

            return winningPlayer;
        }

        public IList<IPlayer> GetPlayers()
        {
            return _players.Values.ToArray();
        }
    }
}
