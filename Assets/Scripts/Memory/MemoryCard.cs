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
}


public class MemoryCPUFlippedCard
{
    public Sprite s;
    public int index;
    public int other_index;
    public bool won;
    public bool seen;

    public MemoryCPUFlippedCard(Sprite sp, int i, int o)
    {
        s = sp;
        index = i;
        other_index = o;
        won = false;
        seen = false;
    }
}



