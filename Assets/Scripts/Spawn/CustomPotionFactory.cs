using Zenject;
using UnityEngine;
//using System;

internal class CustomPotionFactory : IFactory<Object, Potion>
{
    private DiContainer _diContainer;
    public CustomPotionFactory(DiContainer container)
    {
        _diContainer = container;
    }
    public Potion Create(Object prefab)
    {
        return _diContainer.InstantiatePrefabForComponent<Potion>(prefab);
    }
}

