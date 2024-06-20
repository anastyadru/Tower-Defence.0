using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player2>().FromComponentInHierarchy().AsSingle();
    }
}