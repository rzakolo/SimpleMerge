using UnityEngine;
using Zenject;

public class Chest : MonoBehaviour
{
    private PotionSpawner _potionSpawner;
    private PotionTool _tool;

    [Inject]
    private void Construct(PotionSpawner potionSpawner)
    {
        _potionSpawner = potionSpawner;

    }
    private void OnMouseDown()
    {
        _potionSpawner.Spawn();
    }
}
