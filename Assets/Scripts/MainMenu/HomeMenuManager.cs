using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenuManager : MonoBehaviour
{
    public GameObject choose_game_canvas;
    public GameObject choose_mode_canvas;
    public GameObject error_option_canvas;

    private GameTypes current_game_type = GameTypes.none;

    private SaveNumPlayers save_number_players;

    public enum GameTypes
    {
        none,
        memory,
        boxes,
    }

    private const string memory_scene_name = "MemoryScene";
    private const string boxes_scene_name = "BlocksPuzzleScene";
    
    // Start is called before the first frame update
    void Start()
    {
        current_game_type = GameTypes.none;
        save_number_players = GameObject.FindGameObjectWithTag("save_number_players").GetComponent<SaveNumPlayers>();
        ActivateChooseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGameSelection()
    {
        current_game_type = GameTypes.none;
    }

    public void SetMemory()
    {
        current_game_type = GameTypes.memory;   
    }
    
    public void SetBoxesGame()
    {
        current_game_type = GameTypes.boxes;   
    }

    public void ActivateChooseGame()
    {
        choose_game_canvas.SetActive(true);
        choose_mode_canvas.SetActive(false);
        error_option_canvas.SetActive(false);
    }
    
    public void ActivateChooseMode()
    {
        choose_game_canvas.SetActive(false);
        choose_mode_canvas.SetActive(true);
        error_option_canvas.SetActive(false);
    }

    public void LoadNextScene()
    {
        if (!save_number_players.GetPlayOption().Equals(SaveNumPlayers.PlayOptions.none))
        {
            switch (current_game_type)
            {
                case GameTypes.memory:
                    SceneManager.LoadSceneAsync(memory_scene_name);
                    break;
                case GameTypes.boxes:
                    SceneManager.LoadSceneAsync(boxes_scene_name);
                    break;
            }
                
        } else
        {
            StartCoroutine(ShowOptionErrorCanvas());
        }

    }

    IEnumerator ShowOptionErrorCanvas()
    {
        error_option_canvas.SetActive(true);
        yield return new WaitForSeconds(1f);
        error_option_canvas.SetActive(false);
    }
}
