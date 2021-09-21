using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    
    private SaveNumPlayers save_num_players;
    private BoxGameManager box_game_manager;
    
    // Start is called before the first frame update
    void Start()
    {
        save_num_players = GameObject.FindGameObjectWithTag("save_number_players").GetComponent<SaveNumPlayers>();  
        box_game_manager = GameObject.FindGameObjectWithTag("boxManager").GetComponent<BoxGameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
