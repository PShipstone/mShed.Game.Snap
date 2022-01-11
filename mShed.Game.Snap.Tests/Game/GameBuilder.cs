using mShed.Game.Snap.GameProviders;
using System.Collections.Generic;

namespace mShed.Game.Snap.Tests.Game
{
    public class GameBuilder
    {
        private GameType _gameRulesType;
        private List<string> _players = new List<string>();

        public IGame Build()
        {
            var game = new Snap.Game(_gameRulesType);

            _players.ForEach(p => game.RegisterPlayer(p));

            return game;
        }

        public GameBuilder UseStandardGame()
        {
            _gameRulesType = GameType.KidsRules;

            return this;
        }

        public GameBuilder InvalidGameType()
        {
            _gameRulesType = (GameType)int.MaxValue;

            return this;
        }

        public GameBuilder RegisterPlayer(string name)
        {
            _players.Add(name);

            return this;
        }
    }
}
