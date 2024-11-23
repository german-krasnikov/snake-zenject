using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CoinInstaller : Installer<Coin, Transform, CoinInstaller>
    {
        [Inject]
        private Coin _coinPrefab;
        [Inject]
        private Transform _worldTransform;

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<Coin, CoinPool>()
                .WithInitialSize(5)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_coinPrefab)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();

            Container
                .Bind<ICoinSpawner>()
                .To<CoinPool>()
                .FromResolve();
        }
    }
}