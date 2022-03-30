using UnityEngine;
using Zenject;

public class SpawnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PotionSpawner>().AsSingle();
        Container.BindFactory<Object, Potion, PotionFactory>().FromFactory<CustomPotionFactory>();
    }
}