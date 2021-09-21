using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
 
    private SaveNumPlayers save_num_players;
    private BoxGameManager box_game_manager;

    public bool box_game = true;
    
    // Start is called before the first frame update
    void Start()
    {
        save_num_players = GameObject.FindGameObjectWithTag("save_number_players").GetComponent<SaveNumPlayers>();
        switch (save_num_players.GetGameType())
        {
            case (HomeMenuManager.GameTypes.boxes):
                box_game_manager = GameObject.FindGameObjectWithTag("boxManager").GetComponent<BoxGameManager>();
                break;
            case (HomeMenuManager.GameTypes.memory):
                //memory_game_manager = GameObject.FindGameObjectWithTag("memoryManager").GetComponent<MemoryGameManager>();
                break;
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
