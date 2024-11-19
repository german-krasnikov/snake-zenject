using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SampleGame
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        //[SerializeField]
        //private Character _characterPrefab;

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
        }
    }
}