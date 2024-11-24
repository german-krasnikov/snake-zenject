using System;
using Modules;
using UnityEngine;

namespace Gameplay
{
    public interface ICoinController
    {
        
        bool TryEat(Vector2Int position, out Coin coin);
        int Count { get; }
        void SpawnCoins();
        event Action<Coin> OnEat;
    }
}