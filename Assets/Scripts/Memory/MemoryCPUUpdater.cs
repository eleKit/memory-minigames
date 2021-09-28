using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MemoryCPUUpdater : MonoBehaviour
{
    private const int GRID_SIZE = 6;
    
    //public Queue<int> indexesOfSpritesAlreadySeen;

    public MemoryCPUFlippedCard tmp_card;

    public MemoryCPUFlippedCard []  cardsArray = new MemoryCPUFlippedCard [GRID_SIZE *2];
    public List<MemoryCPUFlippedCard> seenCards = new List<MemoryCPUFlippedCard>();

    private void Start()
    {
    }

    public void ResetFlippedList()
    {
       
    }

    public void SetupMatrixCardsCoordinates(List<MemoryCPUFlippedCard> cards)
    {
        if (cards.Count == GRID_SIZE * 2)
        {
            foreach (var c in cards)
            {
                cardsArray[c.index] = c;
            }
        }
        

    }

    public void SetSeenCard(int index)
    {
        cardsArray[index].seen = true;
        seenCards.Add(cardsArray[index]);
    }

    public void SetWonCouple(int index, bool won)
    {
        MemoryCPUFlippedCard c = cardsArray[index];
        c.seen = true;
        if (won)
        {
            c.won = true;
            cardsArray[c.other_index].won = true;
            seenCards.Remove(cardsArray[c.other_index]);
        }
        else
        {
            seenCards.Add(cardsArray[index]);
        }
    }

    public MemoryCPUFlippedCard GetFirstSeenCard()
    {
        if(seenCards.Count > 0)
            return seenCards[Random.Range(0, seenCards.Count)];
        /*foreach (MemoryCPUFlippedCard c in cardsArray)
        {
            if (c.seen && !c.won)
            {
                return c;
            }
        }*/

        /*foreach (MemoryCPUFlippedCard c in cardsArray)
        {
            if (c.won == false)
            {
                return c;
            }
        }*/

        return new MemoryCPUFlippedCard(null, 0, 0, true);
    }

    public bool CheckIfSecondIsSeen(MemoryCPUFlippedCard card)
    {

        return cardsArray[card.other_index].seen;

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
