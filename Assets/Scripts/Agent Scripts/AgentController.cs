using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : Singleton<AgentController>
{
    public class CurrentGameData
    {
        public GameTypes gameTypes;
        public GamesControllers gamesControllers;
    }
    
    public class GamesControllers
    {
        public CPUAgentBlocksGame boxGameManager;
        public MemoryCPU memoryManager;

        public bool IsBoxGame()
        {
            return boxGameManager != null;
        }
        
        public bool IsMemoryGame()
        {
            return memoryManager != null;
        }
    }
    
    public SaveNumPlayers save_num_players;
    private CurrentGameData currentGameData;

    void Awake()
    {

        if (FindObjectsOfType(typeof(AgentController)).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        currentGameData = new CurrentGameData();
        currentGameData.gamesControllers = new GamesControllers();
        currentGameData.gameTypes = save_num_players.GetGameType();
    }


    public void SetupCurrentGame()
    {
        currentGameData.gameTypes = save_num_players.GetGameType();
        switch (currentGameData.gameTypes)
        {
            case GameTypes.boxes:
                currentGameData.gamesControllers.boxGameManager = FindObjectOfType<CPUAgentBlocksGame>();
                currentGameData.gamesControllers.memoryManager = null;
                break;
            case GameTypes.memory:
                currentGameData.gamesControllers.memoryManager = FindObjectOfType<MemoryCPU>();
                currentGameData.gamesControllers.boxGameManager = null;
                break;
        }
    }
}
