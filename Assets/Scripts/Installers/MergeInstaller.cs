using UnityEngine;
using Zenject;

public class MergeInstaller : MonoInstaller
{
    [SerializeField] private LayerMask _layer;
    public override void InstallBindings()
    {
        Container.Bind<LayerMask>().FromMethod(p => _layer);
        Container.Bind<Merge>().AsSingle();
        Container.Bind<Compare>().AsSingle();
    }
}