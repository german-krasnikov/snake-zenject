using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameCycle>().AsSingle();
        //this.Container.Bind<BulletSpawner>().AsSingle().WithArguments(_bulletPrefab);
    }
}
