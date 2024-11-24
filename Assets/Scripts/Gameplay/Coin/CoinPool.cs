using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CoinPool : MonoMemoryPool<Vector2Int, Coin>, ICoinSpawner
    {
        Coin ICoinSpawner.CreateAt(Vector2Int position) => Spawn(position);
        void ICoinSpawner.Remove(Coin coin) => Despawn(coin as Coin);

        protected override void Reinitialize(Vector2Int position, Coin coin)
        {
            coin.Generate();
            coin.Position = position;
        }

        protected override void OnSpawned(Coin item)
        {
            base.OnSpawned(item);
            //item.OnDispose += this.Despawn;
        }

        protected override void OnDespawned(Coin item)
        {
            base.OnDespawned(item);
            //item.OnDispose -= this.Despawn;
        }
    }
}