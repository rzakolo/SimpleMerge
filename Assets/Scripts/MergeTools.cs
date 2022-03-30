using UnityEngine;
using Zenject;

internal class MergeTools : MonoBehaviour
{
    public LayerMask layer;
    private int _layer;
    private PotionTool _items;
    //private float _min = -2.5f;
    //private float _max = 3.5f;
    private int _maxTry = 200;
    private DiContainer _container;
    private PotionSpawner _potionSpawner;

    [Inject]
    private void Construct(DiContainer diContainer, PotionSpawner potionSpawner)
    {
        _container = diContainer;
        _potionSpawner = potionSpawner;

    }
    private void Start()
    {
        _items = GetComponent<PotionTool>();
        _layer = layer.value;
    }
    //public bool Equals(Vector2 position, Vector2 previousPosition)
    //{
    //    var hitInfo = Physics2D.RaycastAll(position, Vector2.zero, 4, _layer);
    //    if (hitInfo.Length > 1)
    //    {
    //        var item1 = hitInfo[0].collider.GetComponent<Potion>();
    //        var item2 = hitInfo[1].collider.GetComponent<Potion>();
    //        if (item1.Name == item2.Name && item1.Grade == item2.Grade && item1.Grade != 4)
    //        {
    //            Debug.Log("Equal:true");//merge items
    //            Merge(position, item1, item2);
    //            return true;
    //        }
    //        else
    //        {
    //            Debug.Log("Equal:false");// return to old position
    //            ReturnToPrevPosition(previousPosition, item1);
    //            return true;
    //        }
    //    }
    //    if (hitInfo.Length == 1 && !CorrectMove(position))
    //    {
    //        hitInfo[0].transform.position = previousPosition;
    //        return true;
    //    }
    //    return false;//change item position
    //}
    //public bool Equals(Potion potion1, Potion potion2)
    //{
    //    if (potion1.Name == potion2.Name && potion1.Grade == potion2.Grade)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    //private bool CorrectMove(Vector2 position)
    //{
    //    Vector2 chestPosition = new Vector2(0.5f, 0.5f);
    //    if (position.x >= _min && position.x <= _max
    //        && position.y >= _min && position.y <= _max
    //        && position != chestPosition)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    //public Vector2 RoundToNearestHalf(Vector2 pos)
    //{
    //    float x = Mathf.Sign(pos.x) * (Mathf.Abs((int)pos.x) + 0.5f);
    //    float y = Mathf.Sign(pos.y) * (Mathf.Abs((int)pos.y) + 0.5f);
    //    return new Vector2(x, y);
    //}
    //public bool GetFreeCellPos(out Vector2 freePosition)
    //{

    //    for (int i = 0; i < _maxTry; i++)
    //    {
    //        Vector2 cellPos = RoundToNearestHalf(new Vector2(Random.Range(_min, _max), Random.Range(_min, _max)));
    //        var hitInfo = Physics2D.RaycastAll(cellPos, Vector2.zero);
    //        if (hitInfo.Length == 0)
    //        {
    //            freePosition = cellPos;
    //            //chest using sound
    //            //chest using animation
    //            return true;
    //        }
    //    }
    //    freePosition = Vector2.zero;
    //    return false;
    //}

    //private void Merge(Vector2 position, Potion potion1, Potion potion2)
    //{
    //    //merge animation


    //    Destroy(potion1.gameObject);
    //    Destroy(potion2.gameObject);
    //    _potionSpawner.Spawn();
    //    //_container.InstantiatePrefab(newPotion.gameObject);
    //    //Instantiate(newPotion).transform.position = position;
    //}
    //private void ReturnToPrevPosition(Vector2 position, Potion potion)
    //{
    //    potion.transform.position = position;
    //    //returning animation
    //    //incorrect move sound
    //}
}
