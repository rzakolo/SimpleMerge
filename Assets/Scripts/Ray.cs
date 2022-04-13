using UnityEngine;

internal class Ray
{
    public Potion[] GetPotionsOnVector(Vector2 position, LayerMask layer)
    {
        var hitInfo = Physics2D.RaycastAll(position, Vector2.zero, 4, layer);
        Potion[] result = new Potion[hitInfo.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = hitInfo[i].collider.GetComponent<Potion>();
        }

        return result;
    }
}

