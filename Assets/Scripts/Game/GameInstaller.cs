using Modules;
using SampleGame;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private Snake _snake;

    [SerializeField]
    private InputMap _inputMap;

    public override void InstallBindings()
    {
        InstallInput();
        Container.BindInterfacesAndSelfTo<GameCycle>().AsSingle();
        Container.Bind<ISnake>().FromInstance(_snake).AsSingle();
    }

    private void InstallInput()
    {
        Container.Bind<InputMap>().FromInstance(_inputMap).AsSingle();
        Container.BindInterfacesTo<MoveInput>().AsSingle();
        Container.BindInterfacesTo<SnakeController>().AsSingle();
    }
}