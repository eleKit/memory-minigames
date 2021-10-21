using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxDataManager : MonoBehaviour
{
    public Dictionary<int,BoxElement> box_items;
    public Dictionary<int,BoxElement> wrong_box_items;

    public void SetupDataManager()
    {
        box_items = new Dictionary<int, BoxElement>();
        wrong_box_items = new Dictionary<int, BoxElement>();
    }

    public void ResetDataManager()
    {
        box_items.Clear();
        wrong_box_items.Clear();
    }
}
