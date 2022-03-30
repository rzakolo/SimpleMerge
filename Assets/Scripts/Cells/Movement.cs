using UnityEngine;

internal class Movement
{
    private readonly float _min = -2.5f;
    private readonly float _max = 3.5f;
    private readonly int _maxTry = 200;

    public bool ValidateMove(Vector2 position)
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
    public void ReturnToPrevPosition(Vector2 prevPosition, Potion potion)
    {
        potion.transform.position = prevPosition;
        //TODO: returning animation
        //TODO: incorrect move sound
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
    public Vector2 RoundToNearestHalf(Vector2 pos)
    {
        float x = Mathf.Sign(pos.x) * (Mathf.Abs((int)pos.x) + 0.5f);
        float y = Mathf.Sign(pos.y) * (Mathf.Abs((int)pos.y) + 0.5f);
        return new Vector2(x, y);
    }
}
