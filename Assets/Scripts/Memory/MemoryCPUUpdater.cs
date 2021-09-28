using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCPUUpdater : MonoBehaviour
{
    private const int GRID_SIZE = 6;
    
    //public Queue<int> indexesOfSpritesAlreadySeen;

    public MemoryCPUFlippedCard tmp_card;

    public Dictionary<Sprite, int> cardButtonsInverseDictionary;
    
    public MemoryCPUFlippedCard []  cardsMatrix = new MemoryCPUFlippedCard [GRID_SIZE *2];

    private void Start()
    {
        cardButtonsInverseDictionary = new Dictionary<Sprite, int>();
       // indexesOfSpritesAlreadySeen = new Queue<int>();
    }

    public void ResetFlippedList()
    {
       // indexesOfSpritesAlreadySeen.Clear();
        cardButtonsInverseDictionary.Clear();
    }

    public void SetupMatrixCardsCoordinates(List<MemoryCPUFlippedCard> cards)
    {
        if (cards.Count == GRID_SIZE * 2)
        {
            foreach (var c in cards)
            {
                cardsMatrix[c.index] = c;
            }
        }
        

    }

    public void AddPairData(MemoryCPUFlippedCard c, bool win)
    {
        if (win)
        {
            //nothing + remember to remove the pair if previously saved in the list of seen
        }
        else
        {
          // add both tmp card and current card c in the dictionary
          // if one already exists (check also the index) add it into the list
        }
        
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

    public void CleanPairsUsed()
    {
        
    }
}
