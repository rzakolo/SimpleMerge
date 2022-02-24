using System;
using UnityEngine;

using Random = UnityEngine.Random;

internal class Items : MonoBehaviour
{
    [SerializeField] private Item[] items;
    public bool GetNextGrade(Potion potion, out Potion newPotion)
    {
        for (int i = 0; i < items.Length; i++)
        {
            for (int k = 0; k < items[i].potionsPrefab.Length; k++)
            {
                if (MergeTools.Equals(items[i].potionsPrefab[k], potion) && potion.Grade < 4)
                {
                    newPotion = items[i].potionsPrefab[k + 1];
                    return true;
                }
            }
        }
        newPotion = null;
        return false;
    }
    public Potion GetItemToChest(int maxItemGrade)
    {
        int itemType = Random.Range(0, items.Length);
        int itemGrade = Random.Range(0, maxItemGrade);
        return items[itemType].potionsPrefab[itemGrade];
    }
}

[Serializable]
internal class Item
{
    public string Name;
    public Potion[] potionsPrefab;
}