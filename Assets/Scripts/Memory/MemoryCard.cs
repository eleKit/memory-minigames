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
    public bool ERROR_CARD = false;

    public MemoryCard(int ind, int other, bool ERROR = false)
    {
        index = ind;
        other_index = other;
        won = false;
        seen = false;
        ERROR_CARD = ERROR;
    }

    public void ResetCard()
    {
        seen = false;
        won = false;
        other_index = 0;
        ERROR_CARD = false;
    }

    public void SetOtherIndex(int other)
    {
        other_index = other;
    }
    

}



