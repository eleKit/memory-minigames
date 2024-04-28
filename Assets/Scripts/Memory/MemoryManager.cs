
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

    public GameObject Player1;
    public GameObject Player2;

    public Text scorePlayer1Text;
    public Text scorePlayer2Text;

    private int scorePlayer1;
    private int scorePlayer2;
    

    private Image player1Image;
    private Image player2Image;

    private Color hilightColor = new Color(0, 1, 1);

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
        player1Image = Player1.GetComponent<Image>();
        player2Image = Player2.GetComponent<Image>();
        scorePlayer1Text = Player1.GetComponentInChildren<Text>();
        scorePlayer2Text = Player2.GetComponentInChildren<Text>();
        scorePlayer1 = 0;
        scorePlayer2 = 0;

        switch (save_num_players.GetPlayOption())
        {
            case PlayOptions.agent:
                cpuIsOn = true;
                Player1.SetActive(true);
                Player2.SetActive(true);
                break;
            case PlayOptions.couple:
                multiplayer = true;
                Player1.SetActive(true);
                Player2.SetActive(true);
                break;
            default:
                Player1.SetActive(true);
                Player2.SetActive(false);
                break;
        }
        
        ResetColors();
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
        player1Image.color = hilightColor;
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
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdatePlayerScores();
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
        Debug.Log(current_turn_is_player || multiplayer);
        if (current_turn_is_player || multiplayer)
        {
            FlipCardPrivate(index);
        }
    }
    
    public void FlipCardAgent(int index)
    {
        if (!current_turn_is_player && cpuIsOn)
        {
            FlipCardPrivate(index);
        }
        
    }
    
    IEnumerator ChangeTurn()
    {
        current_turn_is_player = !current_turn_is_player;
        ResetColors();
        if (current_turn_is_player)
            player1Image.color = hilightColor;
        else 
            player2Image.color = hilightColor;
        
        yield return new WaitForSeconds(2f);
        
        if (!current_turn_is_player)
        {
            if (cpuIsOn)
            {
                EventManager.TriggerEvent("activateTurnCPU",  null);
            }
        }
        
    }

    void ResetColors()
    {
        player1Image.color = Color.white;
        player2Image.color = Color.white;
    }

    private void FlipCardPrivate(int index)
    {
        flipped++;
        Sprite s = memoryDataManager.fixed_cards[index].animalFront.GetComponent<Image>().sprite;
        Debug.Log("here " + flipped);
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
                StartCoroutine(CheckWin(win));
                break;
            default:
                break;

        }
    }

    void UpdatePlayerScores()
    {
        scorePlayer1Text.text = scorePlayer1.ToString();
        scorePlayer2Text.text = scorePlayer2.ToString();
    }

    IEnumerator CheckWin(bool win)
    {
        yield return new WaitForSeconds(0f);
        //TODO positive feedback
        if (win)
        {
            memoryDataManager.fixed_cards[first_card_index].won = true;
            memoryDataManager.fixed_cards[second_card_index].won = true;
            if (current_turn_is_player)
            {
                scorePlayer1 += 1;
            }
            else
            {
                if (multiplayer || cpuIsOn)
                {
                    scorePlayer2 += 1;
                }
            }
            UpdatePlayerScores();
        }
        else
        {
            yield return new WaitForSeconds(8f);
            CoverLoseBacks();
        }
        
        flipped = 0;

        if (cpuIsOn || multiplayer)
        {
            yield return StartCoroutine(ChangeTurn());
        }


        if (CheckVictory())
        {
            //TODO win coroutine
            win_canvas_element.SetActive(true);
            ResetColors();
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
