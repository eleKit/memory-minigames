using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard 
{
    bool flip { get; set; }

    Sprite cardSprite;

    MemoryCard(Sprite sprite)
    {
        flip = false;
        cardSprite = sprite;

    }
   
}

