using UnityEngine;

internal class Compare
{
    private int _layer;
    private Merge _merge;
    private Movement _movement;
    public Compare(LayerMask layerMask, Merge merge, Movement movement)
    {
        _layer = layerMask;
        _merge = merge;
        _movement = movement;
    }
    public bool Equals(Vector2 position, Vector2 previousPosition)
    {
        var hitInfo = Physics2D.RaycastAll(position, Vector2.zero, 4, _layer);
        if (hitInfo.Length > 1)
        {
            var item1 = hitInfo[0].collider.GetComponent<Potion>();
            var item2 = hitInfo[1].collider.GetComponent<Potion>();
            if (item1.Name == item2.Name && item1.Grade == item2.Grade && item1.Grade != 4)
            {
                _merge.Merging(position, item1, item2);
                return true;
            }
            else
            {
                _movement.ReturnToPrevPosition(previousPosition, item1);
                return true;
            }
        }
        if (_movement.ValidateMove(position))
        {
            hitInfo[0].transform.position = previousPosition;
            return true;
        }
        return false;//change item position
    }
    public bool Equals(Potion potion1, Potion potion2)
    {
        if (potion1.Name == potion2.Name && potion1.Grade == potion2.Grade)
        {
            return true;
        }
        return false;
    }
}
