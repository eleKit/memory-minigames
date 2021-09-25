
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class MemoryManager : MonoBehaviour
{
    public Dictionary<int, MemoryCard> cardsButtonsDictionary;
    public List<MemoryCard> cards;

    private List<Sprite> sprites;
    
    public MemoryLevelSelector level_selector;

    public int flipped = 0;

    private int first_card_index;
    private int second_card_index;

    private Sprite currentFlippedSprite;

    public GameObject win_canvas_element;
    public GameObject game_canvas;
    public GameObject level_selection_canvas;
    public bool current_turn_is_player;

    
    // Start is called before the first frame update
    void Start()
    {
        level_selector.SetupLevelGenerator();
        InstantiateCards();
    }
    
    public void GenerateLevel(int level)
    {
        sprites = level_selector.GenerateLevel(level);
        SetupGame();
        CoverAllBacks();
        LoadLeveLUI();
        current_turn_is_player = true;
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

        foreach (var sprite in sprites)
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
        if (current_turn_is_player)
        {
            FlipCardPrivate(index);
        }
    }
    
    public void FlipCardAgent(int index)
    {
        if (!current_turn_is_player)
        {
            FlipCardPrivate(index);
        }
    }

    private void FlipCardPrivate(int index)
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
                second_card_index = index;
                flipped++;
                cardsButtonsDictionary[index].backCard.SetActive(false);
                StartCoroutine(CheckWin(currentFlippedSprite.Equals(s)));
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

        if (CheckVictory())
        {
            //TODO win coroutine
            win_canvas_element.SetActive(true);
        }

    }

    private bool CheckVictory()
    {
        foreach (var key in cardsButtonsDictionary.Keys)
        {
            if (!cardsButtonsDictionary[key].won)
            {
                return false;
            }
        }

        return true;
    }
    
    private void LoadLeveLUI()
    {
        game_canvas.SetActive(true);
        level_selection_canvas.SetActive(false);
        win_canvas_element.SetActive(false);
    }
    
    public void ReloadLevel()
    {
        win_canvas_element.SetActive(false);
        CoverAllBacks();
        flipped = 0;
    }
    
    public void LoadHomeMenu()
    {
        SceneManager.LoadSceneAsync("HomeScene");
    }
}
