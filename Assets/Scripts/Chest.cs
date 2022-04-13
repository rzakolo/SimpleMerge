using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Items items;
    [SerializeField] private int maxItemGrade;
    [SerializeField] private Merge mergeTools;
    private void OnMouseDown()
    {
        if (mergeTools.GetFreeCellPos(out Vector2 position))
        {
            Potion potion = items.GetItemToChest(maxItemGrade);
            Instantiate(potion).transform.position = position;
        }
    }
}
