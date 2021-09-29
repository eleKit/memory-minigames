using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MemoryDataManager : MonoBehaviour
{
    private const int GRID_SIZE = 6;
    
    //public Queue<int> indexesOfSpritesAlreadySeen;

    public MemoryCard []  cardsArray = new MemoryCard [GRID_SIZE *2];
    public Dictionary<int,MemoryCard> seenCards = new Dictionary<int,MemoryCard>();

    private void Start()
    {
    }

    public void ResetFlippedList()
    {
       
    }

    public void SetupMatrixCardsCoordinates(List<MemoryCard> cards)
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
        try
        {
            seenCards.Add(index, cardsArray[index]);
        }
        catch (Exception e)
        {
            //index already exisits
        }
    }

    public void SetWonCouple(int index, bool won)
    {
        MemoryCard c = cardsArray[index];
        if (won)
        {
            c.won = true;
            cardsArray[c.other_index].won = true;
            Debug.Log("Removed cards, index: " + cardsArray[c.other_index].index + " other index: " + cardsArray[c.other_index].other_index);
            Debug.Log("Removed cards, index: " + cardsArray[c.index].index + "other index: " + cardsArray[c.index].other_index);
            Debug.Log("1) true?: " + seenCards.Remove(c.other_index));
            Debug.Log("2) true?: " + seenCards.Remove(c.index));
            LogList();
           
        }
        else
        {
            SetSeenCard(index);
        }
    }

    public void LogList()
    {
        foreach (var c in seenCards.Keys)
        {
            Debug.Log("Added Card Array Values, index: " + seenCards[c].index + " other index: " + seenCards[c].other_index);
        }
        
        Debug.Log("List size finished loop " + seenCards.Keys.Count);
    }

    public MemoryCard GetFirstSeenCard()
    {
        if (seenCards.Keys.Count > 0)
        {
            List<int> keys = new List<int>(seenCards.Keys);
            return seenCards[keys[Random.Range(0, keys.Count)]];
        }
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

        return new MemoryCard(0, 0, true);
    }

    public bool CheckIfSecondIsSeen(MemoryCard card)
    {

        return cardsArray[card.other_index].seen;

    }

    public MemoryCard GetCardAtIndex(int index)
    {
        return cardsArray[index];
    }

    public void AddPairData(MemoryCard c, bool win)
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
