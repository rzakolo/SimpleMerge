using UnityEngine;

internal class Merge : MonoBehaviour
{
    public LayerMask layer;
    private Compare _compare;
    private Ray _ray;
    private int _layer;
    private Items _items;
    private float _min = -2.5f;
    private float _max = 3.5f;
    private int _maxTry = 200;
    private void Start()
    {
        _items = GetComponent<Items>();
        _layer = layer.value;
        _ray = new Ray();
        _compare = new Compare();
    }
    public void TryMerge(Vector2 position, Vector2 previousPosition)
    {
        var potions = _ray.GetPotionsOnVector(position, _layer);

        if (potions.Length > 1 && _compare.Equals(potions[0], potions[1]))
        {
            Debug.Log("Equal:true");
            MergePotion(position, potions[0], potions[1]);

        }
        else if (potions.Length == 1 && CorrectMove(position))
        {
            potions[0].transform.position = position;

        }
        else
        {
            ReturnToPrevPosition(previousPosition, potions[0]);
        }

    }
    public bool CorrectMove(Vector2 position)
    {
        Vector2 chestPosition = new Vector2(0.5f, 0.5f);
        if (position.x >= _min && position.x <= _max
            && position.y >= _min && position.y <= _max
            && position != chestPosition)
        {
            return true;
        }
        return false;
    }
    public static Vector2 RoundToNearestHalf(Vector2 pos)
    {
        float x = Mathf.Sign(pos.x) * (Mathf.Abs((int)pos.x) + 0.5f);
        float y = Mathf.Sign(pos.y) * (Mathf.Abs((int)pos.y) + 0.5f);
        return new Vector2(x, y);
    }
    public bool GetFreeCellPos(out Vector2 freePosition)
    {

        for (int i = 0; i < _maxTry; i++)
        {
            Vector2 cellPos = RoundToNearestHalf(new Vector2(Random.Range(_min, _max), Random.Range(_min, _max)));
            var hitInfo = Physics2D.RaycastAll(cellPos, Vector2.zero);
            if (hitInfo.Length == 0)
            {
                freePosition = cellPos;
                return true;
            }
        }
        freePosition = Vector2.zero;
        return false;
    }

    private void MergePotion(Vector2 position, Potion potion1, Potion potion2)
    {
        //merge animation

        if (_items.GetNextGrade(potion1, out Potion newPotion))
        {
            Destroy(potion1.gameObject);
            Destroy(potion2.gameObject);
            Instantiate(newPotion).transform.position = position;
            //correct merge sound
        }
    }
    private static void ReturnToPrevPosition(Vector2 position, Potion potion)
    {
        potion.transform.position = position;
    }
}
