using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MemoryDataManager : MonoBehaviour
{
    private const int GRID_SIZE = 6;
    
    //public Queue<int> indexesOfSpritesAlreadySeen;

    public Dictionary<int,MemoryCard> fixed_cards = new Dictionary<int, MemoryCard>();
    public Dictionary<int,MemoryCard> seenCards = new Dictionary<int,MemoryCard>();
    public Dictionary<int, MemoryCard> notWonCards = new Dictionary<int,MemoryCard>();
    

    public void ResetFlippedList()
    {
        foreach (var key in fixed_cards.Keys)
        {
            fixed_cards[key].backCard.SetActive(true);
            fixed_cards[key].ResetCard();
        }
        
        ClearDataLists();
    }

    public void ClearDataLists()
    {
        seenCards.Clear();
        notWonCards.Clear();
    }

    public void SetupNotWonCards()
    {
        foreach (var key in fixed_cards.Keys)
        {
         notWonCards.Add(key, fixed_cards[key]);   
        }
        
    }

    private void RemoveWonCard(int key)
    {
        notWonCards.Remove(key);
    }

    private void RemoveSeenCard(int key)
    {
        seenCards.Remove(key);
    }

    public void SetSeenCard(int index)
    {
        fixed_cards[index].seen = true;
        try
        {
            seenCards.Add(index, fixed_cards[index]);
        }
        catch (Exception e)
        {
            //index already exisits
        }
    }

    public void SetWonCouple(int index, bool won)
    {
        MemoryCard c = fixed_cards[index];
        if (won)
        {
            c.won = true;
            fixed_cards[c.other_index].won = true;
            RemoveSeenCard(c.other_index);
            RemoveSeenCard(c.index);
            RemoveWonCard(c.other_index);
            RemoveWonCard(c.index);
           
        }
        else
        {
            SetSeenCard(index);
        }
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

        return null;
    }

    public bool CheckIfSecondIsSeen(MemoryCard card)
    {

        return fixed_cards[card.other_index].seen;

    }

    public MemoryCard GetCardAtIndex(int index)
    {
        return fixed_cards[index];
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
