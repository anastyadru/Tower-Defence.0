using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<NavMeshAgent>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Enemy>().AsSingle();
    }
}