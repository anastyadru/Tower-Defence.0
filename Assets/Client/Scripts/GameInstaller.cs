using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerManager>().AsSingle();
        Container.Bind<GameM>().AsSingle();
        Container.Bind<Player>().AsSingle();
        Container.Bind<Player2>().AsSingle();
    }
}