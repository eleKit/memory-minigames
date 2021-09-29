using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
        ERROR_CARD = false;
    }

    public void SetIndexes(int ind, int other)
    {
        index = ind;
        other_index = other;
    }

}



