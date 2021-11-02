using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveNumPlayers : Singleton<SaveNumPlayers>
{

    //TODO when publish make this PlayOptions.none
    private PlayOptions play_option = PlayOptions.agent;

    private GameTypes game_type;
    void Awake()
    {

        if (FindObjectsOfType(typeof(SaveNumPlayers)).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
       // play_option = PlayOptions.none;
       // game_type = HomeMenuManager.GameTypes.none;
    }

    public void SetPlayOption(PlayOptions option)
    {
        play_option = option;
    }

    public PlayOptions GetPlayOption()
    {
        return play_option;
    }

    public void ResetPlayOption()
    {
        play_option = PlayOptions.none;
    }

    public void SetSinglePlayer()
    {
        play_option = PlayOptions.single;
    }
    
    public void SetCPU()
    {
        play_option = PlayOptions.agent;
    }
    
    public void Set2Players()
    {
        play_option = PlayOptions.couple;
    }

    public void SetGameType(GameTypes type)
    {
        game_type = type;
    }

    public GameTypes GetGameType()
    {
        return game_type;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
