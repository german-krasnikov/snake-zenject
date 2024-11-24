using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Gameplay.UI
{
    public class GameUIPresenter : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly GameCycle _gameCycle;
        private readonly IDifficulty _difficulty;
        private IScore _score;

        public GameUIPresenter(
            IGameUI gameUI,
            GameCycle gameCycle,
            IDifficulty difficulty,
            IScore score)
        {
            _gameUI = gameUI;
            _gameCycle = gameCycle;
            _difficulty = difficulty;
            _score = score;
        }

        void IInitializable.Initialize()
        {
            _gameCycle.OnStartGame += Invalidate;
            _gameCycle.OnWin += WinHandler;
            _gameCycle.OnLose += LoseHandler;
        }

        void IDisposable.Dispose()
        {
            _gameCycle.OnStartGame -= Invalidate;
            _gameCycle.OnWin -= WinHandler;
            _gameCycle.OnLose -= LoseHandler;
        }

        private void Invalidate()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
            _gameUI.SetScore(_score.Current.ToString());
        }

        private void LoseHandler()
        {
            _gameUI.GameOver(false);
        }

        private void WinHandler()
        {
            _gameUI.GameOver(true);
        }
    }
}