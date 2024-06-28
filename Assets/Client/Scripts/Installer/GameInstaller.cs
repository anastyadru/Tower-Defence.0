using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ObjectPool>().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player2>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameM>().FromComponentInHierarchy().AsSingle();
    }
}