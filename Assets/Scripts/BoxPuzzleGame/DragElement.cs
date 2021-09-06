﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DragElement : MonoBehaviour
{
    private BoxGameManager box_game_manager;
    public int x_grid_index_current = -1;
    public int y_grid_index_current = -1;

    private void Start()
    {
        box_game_manager = GameObject.FindGameObjectWithTag("boxManager").GetComponent<BoxGameManager>();
    }


    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            this.GetComponent<Transform>().position = curPosition;
            
    }

    IEnumerator OnMouseUp()
    {
        yield return new WaitForSeconds(0.2f);
        box_game_manager.SetPositionBasedOnVector3(this.GetComponent<Transform>());
    }

    private void OnMouseDown()
    {
        Transform me = this.GetComponent<Transform>();
        if (!box_game_manager.current_element_transform.Equals(me))
        {
            box_game_manager.SetCurrentTransform(me);
        }
    }
}
