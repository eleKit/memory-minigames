using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public GameObject animalFront;
    public GameObject backCard;
    public bool won;
    public int index;
    public bool seen;
    public int other_index;


    public void ResetCard()
    {
        seen = false;
        won = false;
        other_index = 0;
    }

    public void SetOtherIndex(int other)
    {
        other_index = other;
    }
    

}



