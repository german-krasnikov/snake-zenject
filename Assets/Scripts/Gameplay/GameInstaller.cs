using Gameplay.UI;
using Modules;
using SampleGame;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private Coin _coinPrefab;
        [SerializeField]
        private Snake _snake;
        [SerializeField]
        private WorldBounds _worldBounds;
        [SerializeField]
        private GameUI _gameUI;
        [SerializeField]
        private InputMap _inputMap;
        [SerializeField]
        private int _maxDifficulty;
        [SerializeField]
        private Transform _poolTransform;

        public override void InstallBindings()
        {
            InstallInput();
            Container.BindInterfacesTo<Score>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreController>().AsSingle();
            Container.BindInterfacesTo<Difficulty>().AsSingle().WithArguments(_maxDifficulty);
            Container.BindInterfacesTo<SnakeController>().AsSingle();
            Container.Bind<ISnake>().FromInstance(_snake).AsSingle();
            Container.Bind<IWorldBounds>().FromInstance(_worldBounds).AsSingle();
            Container.BindInterfacesTo<CoinController>().AsSingle();
            CoinInstaller.Install(Container, _coinPrefab, _poolTransform);
            InstallUI();
            Container.BindInterfacesAndSelfTo<GameCycle>().AsSingle();
        }

        private void InstallInput()
        {
            Container.Bind<InputMap>().FromInstance(_inputMap).AsSingle();
            Container.BindInterfacesTo<MoveInput>().AsSingle();
        }

        private void InstallUI()
        {
            Container.Bind<IGameUI>().FromInstance(_gameUI).AsSingle();
            Container.BindInterfacesTo<GameUIPresenter>().AsSingle();
        }
    }
}