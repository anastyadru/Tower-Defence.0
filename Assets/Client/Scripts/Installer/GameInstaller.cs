// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ObjectPool>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameM>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IPlayer>().To<Player>().AsSingle();
        Container.Bind<PlayerManager>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<Player2>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<IPoolable>().To<Bullet>().AsTransient();
    }
}