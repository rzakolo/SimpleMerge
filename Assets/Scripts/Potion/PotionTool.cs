using UnityEngine;

internal class PotionTool
{

    private Potion[] _items;
    private AllPotions _allPotions;

    public PotionTool(Potion[] items, AllPotions allPotions)
    {
        _items = items;
        _allPotions = allPotions;
    }
    public bool GetNextGrade(Potion potion, out Potion newPotion)
    {
        for (int i = 0; i < _allPotions.potionList.Length; i++)
        {
            if (_allPotions.potionList[i].Name == potion.Name && potion.Grade < 4)
            {
                if (_allPotions.potionList[i].Grade == potion.Grade)
                {
                    newPotion = _allPotions.potionList[i + 1];
                    return true;
                }
            }
        }
        newPotion = null;
        return false;
    }
    public Potion GetItemToChest()
    {
        int itemType = Random.Range(0, _items.Length);
        return _items[itemType];
    }
}