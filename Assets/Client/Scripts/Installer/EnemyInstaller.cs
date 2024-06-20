
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UnityEngine.AI.NavMeshAgent>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Enemy>().AsSingle();
    }
}