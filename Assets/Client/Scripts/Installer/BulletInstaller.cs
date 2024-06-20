using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ObjectPool>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<Bullet>().AsSingle();
    }
}