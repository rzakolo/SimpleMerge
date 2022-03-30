using UnityEngine;

internal class PotionSpawner
{
    readonly private PotionFactory _customPotionFactory;
    private PotionTool _tool;
    private Movement _movement;

    public PotionSpawner(PotionFactory customPotionFactory, PotionTool potionTool, Movement movement)
    {
        _customPotionFactory = customPotionFactory;
        _tool = potionTool;
        _movement = movement;
    }
    public void Spawn()
    {
        Potion potionPrefab = _tool.GetItemToChest();
        if (_movement.GetFreeCellPos(out Vector2 position))
        {
            potionPrefab.transform.position = position;
            _customPotionFactory.Create(potionPrefab);
        }
    }
    public void Spawn(Vector2 pos, Potion potionPrefab)
    {
        potionPrefab.transform.position = pos;
        _customPotionFactory.Create(potionPrefab);
    }
}
