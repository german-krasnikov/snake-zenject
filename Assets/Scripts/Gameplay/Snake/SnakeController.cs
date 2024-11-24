using System;
using Gameplay;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class SnakeController : ITickable, IInitializable, IDisposable
    {
        private readonly IMoveInput _moveInput;
        private readonly GameCycle _gameCycle;
        private readonly ISnake _snake;
        private readonly ICoinController _coinController;
        private readonly IWorldBounds _worldBounds;
        private readonly IDifficulty _difficulty;

        public SnakeController(
            IMoveInput moveInput,
            GameCycle gameCycle,
            ISnake snake,
            ICoinController coinController,
            IWorldBounds worldBounds,
            IDifficulty difficulty)
        {
            _moveInput = moveInput;
            _gameCycle = gameCycle;
            _snake = snake;
            _coinController = coinController;
            _worldBounds = worldBounds;
            _difficulty = difficulty;
        }

        void IInitializable.Initialize()
        {
            _snake.OnSelfCollided += _gameCycle.LoseGame;
            _snake.OnMoved += MovedHandler;
        }

        void IDisposable.Dispose()
        {
            _snake.OnSelfCollided -= _gameCycle.LoseGame;
            _snake.OnMoved -= MovedHandler;
        }

        void ITickable.Tick()
        {
            if (!_gameCycle.IsPlaying)
                return;

            _snake.Turn(_moveInput.GetMoveDirection());
        }

        private void MovedHandler(Vector2Int position)
        {
            if (!_worldBounds.IsInBounds(position))
            {
                _gameCycle.LoseGame();
                return;
            }

            if (_coinController.TryEat(position, out Coin coin))
            {
                _snake.Expand(coin.Bones);
                if (_coinController.Count == 0)
                {
                    if (_difficulty.Next(out int difficulty))
                    {
                        _coinController.SpawnCoins();
                        _snake.SetSpeed(difficulty);
                    }
                    else
                    {
                        _gameCycle.WinGame();
                    }
                }
            }
        }
    }
}