using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CoinPool : MonoMemoryPool<Vector2, Coin>, ICoinSpawner
    {
        public ICoin CreateAt(Vector2Int position) => Spawn(position);
    }
}