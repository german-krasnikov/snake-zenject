using Modules;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class SnakeInstaller : MonoInstaller
    {
        [SerializeField]
        private Snake _snake;

        [SerializeField]
        private InputMap _inputMap;

        public override void InstallBindings()
        {
            InstallInput();
        }

        private void InstallInput()
        {
            Container.Bind<InputMap>().FromInstance(_inputMap).AsSingle();
            Container.BindInterfacesTo<MoveInput>().AsSingle();
            Container.Bind<ISnake>().FromInstance(_snake).AsSingle();
            Container.BindInterfacesTo<SnakeController>().AsSingle();
        }
    }
}