using Gameplay;
using Modules;
using SampleGame;
using SnakeGame;
using UnityEngine;
using Zenject;

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
    private Transform _poolTransform;

    public override void InstallBindings()
    {
        InstallInput();
        Container.BindInterfacesTo<Score>().AsSingle();
        Container.BindInterfacesTo<Difficulty>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameCycle>().AsSingle();
        Container.BindInterfacesTo<SnakeController>().AsSingle();
        Container.Bind<ISnake>().FromInstance(_snake).AsSingle();
        Container.Bind<IGameUI>().FromInstance(_gameUI).AsSingle();
        Container.Bind<IWorldBounds>().FromInstance(_worldBounds).AsSingle();
        CoinInstaller.Install(Container, _coinPrefab, _poolTransform);
    }

    private void InstallInput()
    {
        Container.Bind<InputMap>().FromInstance(_inputMap).AsSingle();
        Container.BindInterfacesTo<MoveInput>().AsSingle();
    }
}