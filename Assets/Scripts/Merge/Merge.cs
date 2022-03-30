using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Merge
{
    PotionSpawner _potionSpawner;
    private PotionTool _tool;
    public Merge(PotionSpawner potionSpawner, PotionTool potionTool)
    {
        _potionSpawner = potionSpawner;
        _tool = potionTool;
    }
    public void Merging(Vector2 position, Potion potion1, Potion potion2)
    {
        //TODO: merge animation
        potion1.Destroy();
        potion2.Destroy();
        if (_tool.GetNextGrade(potion1, out Potion newPotion))
            _potionSpawner.Spawn(position, newPotion);
    }
}
