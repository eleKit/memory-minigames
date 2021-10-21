using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxElement
{
    private readonly Transform _transform;
    private readonly DragElement _dragElement;
    private readonly SpriteRenderer _spriteRenderer;
    public bool win;

    public BoxElement(Transform t, DragElement d, SpriteRenderer s)
    {
        _transform = t;
        _dragElement = d;
        _spriteRenderer = s;
        win = false;
    }

    public Transform GetTransform()
    {
        return _transform;
    }
    

    public DragElement GetDragElement()
    {
        return _dragElement;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return _spriteRenderer;
    }
    
}


public class IntCoordinates
{
    public int x;
    public int y;

}