// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ObjectPool>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Bullet>().AsTransient(); // Используем AsTransient для создания новых экземпляров
        Container.Bind<IPoolable>().To<Bullet>().AsTransient(); // Привязываем IPoolable к Bullet
    }
}