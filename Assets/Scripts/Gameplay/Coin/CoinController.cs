using System;
using System.Collections.Generic;
using System.Linq;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CoinController : IInitializable, IDisposable, ICoinController
    {
        public event Action<Coin> OnEat;

        private readonly ICoinSpawner _coinSpawner;
        private readonly GameCycle _gameCycle;
        private readonly IDifficulty _difficulty;
        private readonly IWorldBounds _worldBounds;

        private readonly Dictionary<Coin, Vector2Int> _coins = new();
        public int Count => _coins.Count;

        public CoinController(ICoinSpawner coinSpawner, GameCycle gameCycle, IDifficulty difficulty, IWorldBounds worldBounds)
        {
            _coinSpawner = coinSpawner;
            _gameCycle = gameCycle;
            _difficulty = difficulty;
            _worldBounds = worldBounds;
        }

        void IInitializable.Initialize()
        {
            _gameCycle.OnStartGame += SpawnCoins;
            _gameCycle.OnLose += Clean;
        }

        void IDisposable.Dispose()
        {
            _gameCycle.OnStartGame -= SpawnCoins;
            _gameCycle.OnLose -= Clean;
        }

        public bool TryEat(Vector2Int position, out Coin coin)
        {
            if (!HasCoin(position))
            {
                coin = null;
                return false;
            }

            coin = GetCoin(position);
            _coinSpawner.Remove(coin);
            _coins.Remove(coin);
            OnEat?.Invoke(coin);
            return true;
        }

        public void SpawnCoins()
        {
            var count = _difficulty.Current;

            for (var i = 0; i < count; i++)
            {
                SpawnCoin();
            }
        }


        private void Clean()
        {
            foreach (var coin in _coins.Keys)
            {
                _coinSpawner.Remove(coin);
            }
        }

        private void SpawnCoin()
        {
            var position = GetRandomPosition();
            var coin = _coinSpawner.CreateAt(position);
            _coins.Add(coin, position);
        }

        private Coin GetCoin(Vector2Int position) => _coins.First(x => x.Value == position).Key;
        private bool HasCoin(Vector2Int position) => _coins.Values.Contains(position);

        private Vector2Int GetRandomPosition()
        {
            var position = _worldBounds.GetRandomPosition();

            while (HasCoin(position))
            {
                position = _worldBounds.GetRandomPosition();
            }

            return position;
        }
    }
}