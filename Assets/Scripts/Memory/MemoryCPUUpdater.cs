using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCPUUpdater : MonoBehaviour
{
    public List<int> indexesOfSpritesAlreadySeen;

    public MemoryCPUFlippedCard tmp_card;

    public Dictionary<Sprite, int> cardButtonsInverseDictionary;

    private void Start()
    {
        cardButtonsInverseDictionary = new Dictionary<Sprite, int>();
        indexesOfSpritesAlreadySeen = new List<int>();
    }

    public void ResetFlippedList()
    {
        indexesOfSpritesAlreadySeen.Clear();
        cardButtonsInverseDictionary.Clear();
    }

    public void AddPairData(MemoryCPUFlippedCard c, bool win)
    {
        /*TODO gestire 4 casi:
         1) si è vinto
         2) si è perso e nessuna carta era uscita mai
         3) si è perso e una carta era uscita
         4) si è perso e due carte erano uscite
         
         tenendo in considerazione che le carte già uscite sono nel dictionary e 
         quindi vanno messe nella lista, quando poi si vincerà gli indici vanno tolti dalla lista
         
         quando si vince gli indici vanno sempre tolti dalla lista
         
         */
    }
}
