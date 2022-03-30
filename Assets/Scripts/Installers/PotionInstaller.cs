using UnityEngine;
using Zenject;

public class PotionInstaller : MonoInstaller
{
    [SerializeField] Potion[] lowGradePotions;
    [SerializeField] AllPotions allPotions;
    public override void InstallBindings()
    {
        Container.Bind<Potion[]>().FromMethod(p => lowGradePotions);
        Container.Bind<AllPotions>().FromMethod(p => allPotions);
        Container.Bind<PotionTool>().AsSingle();
    }
}