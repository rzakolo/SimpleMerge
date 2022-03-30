using System;
using UnityEngine;
using Zenject;

internal class Potion : MonoBehaviour
{
    public string Name;
    public int Grade;

    private Player _player;
    private Compare _compare;
    private Movement _movement;
    private Vector2 _mousePosition;
    private Vector2 _previousPosition;
    private bool _onDrag;

    private float _timer;
    private float _doubleClick = .3f;
    private int click;



    [Inject]
    private void Construct(Player player, Compare compare, Movement movement)
    {
        _compare = compare;
        _player = player;
        _movement = movement;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
    private void OnMouseDrag()
    {
        if (!_onDrag)
        {
            _previousPosition = transform.position;
        }
        _onDrag = true;
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _mousePosition;
    }
    private void OnMouseUp()
    {
        _onDrag = false;

        Vector2 newPosition = _movement.RoundToNearestHalf(transform.position);
        if (_compare.Equals(newPosition, _previousPosition) == false)
        {
            transform.position = newPosition;
        }
        Debug.Log("Dragged");
        DoubleClick();
    }
    private void DoubleClick()
    {
        click++;
        if (_timer > _doubleClick)
            click = 0;
        if (click >= 1 && Grade == 4)
        {
            Sell();
        }
        _timer = 0;
    }

    private void Sell()
    {
        _player.GetExp();
        Destroy(gameObject);
    }
    internal void Destroy()
    {
        Destroy(gameObject);
    }
}


