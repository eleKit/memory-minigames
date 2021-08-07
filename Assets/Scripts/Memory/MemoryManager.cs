
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class MemoryManager : MonoBehaviour
{
    public Sprite[] testSprites;
    
    public Sprite[] animalSprites;
    public Sprite[] emojiSprites;
    public Sprite[] chibiSprites;

    public Dictionary<int, MemoryCard> cardsButtonsDictionary;
    public List<MemoryCard> cards;

    public int flipped = 0;

    private int first_card_index;
    private int second_card_index;

    private Sprite currentFlippedSprite;

    
    // Start is called before the first frame update
    void Start()
    {
        InstantiateCards();
        SetupGame();
        CoverAllBacks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InstantiateCards()
    {
        cards = new List<MemoryCard>();
        cardsButtonsDictionary = new Dictionary<int, MemoryCard>();
        var fowt = GameObject.FindGameObjectsWithTag("card");
        for(int i =0; i < fowt.Length; i++)
        {
            var mc = fowt[i].GetComponent<MemoryCard>();
            cards.Add(mc);
            cardsButtonsDictionary.Add(i,mc);
        }
    }

    void ShuffleList<T>(List<T> l)
    {
        System.Random rng = new System.Random();
        int n = l.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = l[k];
            l[k] = l[n];
            l[n] = value;

        }

    }

    void SetupGame()
    {
        flipped = 0;

        ShuffleList(cards);
        
        int keyOfIndexes = 0;

        foreach (var sprite in emojiSprites)
        {
            for (int j=0; j< 2; j++)
            {
                if (keyOfIndexes < cards.Count)
                {
                    cards[keyOfIndexes].animalFront.GetComponent<Image>().sprite = sprite;
                    keyOfIndexes++;
                }
            }
        }
    }

    void CoverAllBacks()
    {
        foreach (var card in cards)
        {
            card.backCard.SetActive(true);
            card.won = false;
        }
    }

    void CoverLoseBacks()
    {
        foreach (var mc in cardsButtonsDictionary.Values)
        {
            if (!mc.won)
            {
                mc.backCard.SetActive(true);
            }
        }
    }


    public void FlipCard(int index)
    {
        Sprite s = cardsButtonsDictionary[index].animalFront.GetComponent<Image>().sprite;
        switch (flipped)
        {
            case 0:
                currentFlippedSprite = s;
                first_card_index = index;
                cardsButtonsDictionary[index].backCard.SetActive(false);
                flipped++;
                break;
            case 1:
                cardsButtonsDictionary[index].backCard.SetActive(false);
                second_card_index = index;
                StartCoroutine(CheckWin(currentFlippedSprite.Equals(s)));
                flipped++;
                break;
            default:
                break;

        }
    }

    IEnumerator CheckWin(bool win)
    {
        yield return new WaitForSeconds(0f);
        //TODO positive feedback
        if (win)
        {
            Debug.Log("hai vinto");
            cardsButtonsDictionary[first_card_index].won = true;
            cardsButtonsDictionary[second_card_index].won = true;
        }
        else
        {
            Debug.Log("hai perso");
            yield return new WaitForSeconds(2f);
            CoverLoseBacks();
        }

        flipped = 0;

    }
}
