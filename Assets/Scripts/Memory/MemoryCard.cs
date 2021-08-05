using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    bool flip { get; set; }

    public GameObject cardBack;
    
    // Start is called before the first frame update
    void Start()
    {
        flip = false;
        cardBack.SetActive(true);
    }

    void FlipCard(bool b)
    {
        cardBack.SetActive(b);
        flip = b;
    }

    public void OnMouseDown()
    {
        FlipCard(true);
    }
}

