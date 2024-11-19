using Zenject;

namespace SampleGame
{
    public sealed class InputInstaller : Installer<InputMap, InputInstaller>
    {
        [Inject]
        private InputMap _inputMap; //DiContainer or Args
        
        public override void InstallBindings()
        {
            this.Container.Bind<InputMap>().FromInstance(_inputMap).AsSingle();
            this.Container.BindInterfacesTo<MoveInput>().AsSingle();
        }
    }
}