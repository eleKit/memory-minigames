
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class MemoryManager : MonoBehaviour
{
    private Dictionary<int,MemoryCard> fixed_cards;

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

    private MemoryDataManager memoryDataManager;


    // Start is called before the first frame update
    void Start()
    {
        memoryDataManager = GameObject.FindGameObjectWithTag("memoryCPUupdater").GetComponent<MemoryDataManager>();
        fixed_cards = new Dictionary<int, MemoryCard>();
        level_selector.SetupLevelGenerator();
        InstantiateCards();
        LoadLevelMenu();
    }
    
    public void GenerateLevel(string level)
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

    #region Initialization

    
    void InstantiateCards()
    {
        var fowt = GameObject.FindGameObjectsWithTag("card");
        for (int i = 0; i<fowt.Length; i++)
        {
            var mc = fowt[i].GetComponent<MemoryCard>();
            fixed_cards.Add(i,mc);
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

        List<int> tmp_cards_indexes = new List<int>(fixed_cards.Keys);

        ShuffleList(tmp_cards_indexes);
        
        int keyOfIndexes = 0;
        
        foreach (var sprite in sprites)
        {
            MemoryCard[] mc = new MemoryCard[2];
            for (int j=0; j< 2; j++)
            {
                if (keyOfIndexes < tmp_cards_indexes.Count)
                {
                    mc[j] = fixed_cards[tmp_cards_indexes[keyOfIndexes]];
                    mc[j].animalFront.GetComponent<Image>().sprite = sprite;
                    memoryDataManager.cardsArray[mc[j].index]= mc[j];
                    keyOfIndexes++;
                }
            }

            memoryDataManager.cardsArray[mc[0].index].other_index = memoryDataManager.cardsArray[mc[1].index].index;
            memoryDataManager.cardsArray[mc[1].index].other_index = memoryDataManager.cardsArray[mc[0].index].index;
        }
        
    }
    
    #endregion

    void CoverAllBacks()
    {
        memoryDataManager.ResetFlippedList();
    }

    void CoverLoseBacks()
    {
        foreach (var mc in memoryDataManager.cardsArray)
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
        flipped++;
        Sprite s = memoryDataManager.cardsArray[index].animalFront.GetComponent<Image>().sprite;
        switch (flipped)
        {
            case 1:
                currentFlippedSprite = s;
                first_card_index = index;
                memoryDataManager.cardsArray[index].backCard.SetActive(false);
                memoryDataManager.SetSeenCard(index);
                break;
            case 2:
                second_card_index = index;
                memoryDataManager.cardsArray[index].backCard.SetActive(false);
                bool win = currentFlippedSprite.Equals(s);
                memoryDataManager.SetWonCouple(index,win);
                StartCoroutine(CheckWin(win));
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
            memoryDataManager.cardsArray[first_card_index].won = true;
            memoryDataManager.cardsArray[second_card_index].won = true;
        }
        else
        {
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
        foreach (var card in memoryDataManager.cardsArray)
        {
            if (!card.won)
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

    public void LoadLevelMenu()
    {
        game_canvas.SetActive(false);
        level_selection_canvas.SetActive(true);
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
