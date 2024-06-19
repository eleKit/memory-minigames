using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenuManager : MonoBehaviour
{
    public GameObject choose_game_canvas;
    public GameObject choose_mode_canvas;
    public GameObject error_option_canvas;
    public Slider slider_memory;

    private GameTypes current_game_type = GameTypes.none;

    private SaveNumPlayers save_number_players;

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


    public void ActivateChooseGame()
    {
        choose_game_canvas.SetActive(true);
        choose_mode_canvas.SetActive(false);
        error_option_canvas.SetActive(false);
    }
    
    public void ActivateChooseMode(bool box)
    {
        if (box)
        {
            current_game_type = GameTypes.boxes;   
            LoadNextScene(0);
        }
        else
        {
            current_game_type = GameTypes.memory;
            choose_game_canvas.SetActive(false);
            choose_mode_canvas.SetActive(true);
            error_option_canvas.SetActive(false);
        }

        
    }

    public void LoadNextScene(int i)
    {
        switch (i)
        {
            case 1:
                save_number_players.SetCPU();
                break;
            case 2:
                save_number_players.Set2Players();
                break;
            default:
                save_number_players.SetSinglePlayer();
                break;
        }
        save_number_players.SetGameType(current_game_type);
        switch (current_game_type)
            {
                case GameTypes.memory:
                    save_number_players.memory_card_speed = slider_memory.value;
                    Debug.Log(save_number_players.memory_card_speed);
                    Debug.Log(slider_memory.value);
                    SceneManager.LoadSceneAsync(memory_scene_name);
                    break;
                case GameTypes.boxes:
                    SceneManager.LoadSceneAsync(boxes_scene_name);
                    break;
            }

    }
    
}
