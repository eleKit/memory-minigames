
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class MemoryManager : MonoBehaviour
{
    private List<Sprite> sprites;
    
    public MemoryLevelSelector level_selector;
    
    private SaveNumPlayers save_num_players;

    public int flipped = 0;

    private int first_card_index;
    private int second_card_index;

    public GameObject win_canvas_element;
    public GameObject game_canvas;
    public GameObject level_selection_canvas;
    public bool current_turn_is_player;

    private MemoryDataManager memoryDataManager;

    private bool cpuIsOn;
    private bool multiplayer;


    // Start is called before the first frame update
    void Start()
    {
        memoryDataManager = GameObject.FindGameObjectWithTag("memoryCPUupdater").GetComponent<MemoryDataManager>();
        save_num_players = GameObject.FindGameObjectWithTag("save_number_players").GetComponent<SaveNumPlayers>();

        switch (save_num_players.GetPlayOption())
        {
            case SaveNumPlayers.PlayOptions.agent:
                cpuIsOn = true;
                break;
            case SaveNumPlayers.PlayOptions.couple:
                multiplayer = true;
                break;
        }
        
        level_selector.SetupLevelGenerator();
        InstantiateCards();
        LoadLevelMenu();
    }
    
    public void GenerateLevel(string level)
    {
        sprites = level_selector.GenerateLevel(level);
        LoadLeveLUI();
        CleanLevel();
        SetupGame();
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
        foreach (var t in fowt)
        {
            var mc = t.GetComponent<MemoryCard>();
            memoryDataManager.fixed_cards.Add(mc.index,mc);
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

        List<int> tmp_cards_indexes = new List<int>(memoryDataManager.fixed_cards.Keys);

        ShuffleList(tmp_cards_indexes);
        
        int keyOfIndexes = 0;
        
        foreach (var sprite in sprites)
        {
            int[] mc = new int[2];
            for (int j=0; j< 2; j++)
            {
                if (keyOfIndexes < tmp_cards_indexes.Count)
                {
                    memoryDataManager.fixed_cards[tmp_cards_indexes[keyOfIndexes]].animalFront.GetComponent<Image>().sprite = sprite;
                    mc[j] = keyOfIndexes;
                    keyOfIndexes++;
                }
            }

            memoryDataManager.fixed_cards[tmp_cards_indexes[mc[0]]].SetOtherIndex(tmp_cards_indexes[mc[1]]);
            memoryDataManager.fixed_cards[tmp_cards_indexes[mc[1]]].SetOtherIndex(tmp_cards_indexes[mc[0]]);
            
        }
        
        memoryDataManager.SetupNotWonCards();
        //memoryDataManager.LogArray();
        
    }
    
    #endregion

    void CoverAllBacks()
    {
        foreach (var go in memoryDataManager.fixed_cards.Values)
        {
            go.backCard.SetActive(true);
            go.won = false;
            go.seen = false;
        }
        
        memoryDataManager.ClearDataLists();
    }

    void CleanLevel()
    {
        memoryDataManager.ResetFlippedList();
    }

    void CoverLoseBacks()
    {
        foreach (var mc in memoryDataManager.fixed_cards.Values)
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
    
    void ChangeCPUTurn()
    {
        current_turn_is_player = !current_turn_is_player;
    }

    private void FlipCardPrivate(int index)
    {
        flipped++;
        Sprite s = memoryDataManager.fixed_cards[index].animalFront.GetComponent<Image>().sprite;
        switch (flipped)
        {
            case 1:
                first_card_index = index;
                memoryDataManager.fixed_cards[index].backCard.SetActive(false);
                memoryDataManager.SetSeenCard(index);
                break;
            case 2:
                second_card_index = index;
                memoryDataManager.fixed_cards[index].backCard.SetActive(false);
                bool win = first_card_index.Equals(memoryDataManager.fixed_cards[index].other_index);
                memoryDataManager.SetWonCouple(index,win);
                if (cpuIsOn)
                {
                    ChangeCPUTurn();
                }
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
            memoryDataManager.fixed_cards[first_card_index].won = true;
            memoryDataManager.fixed_cards[second_card_index].won = true;
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
        foreach (var card in memoryDataManager.fixed_cards.Values)
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
        memoryDataManager.SetupNotWonCards();
        flipped = 0;
    }
    
    public void LoadHomeMenu()
    {
        SceneManager.LoadSceneAsync("HomeScene");
    }
}
