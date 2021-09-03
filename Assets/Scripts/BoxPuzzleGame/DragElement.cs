using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DragElement : MonoBehaviour
{
 

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            this.GetComponent<Transform>().position = curPosition;


    }



}
