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

    public MemoryCPUFlippedCard(Sprite sp, int i)
    {
        s = sp;
        index = i;
    }
}



