using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Enemy>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UnityEngine.AI.NavMeshAgent>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ObjectPool>().FromComponentInHierarchy().AsSingle();
    }
}