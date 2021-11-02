using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : Singleton<AgentController>
{
    public GameTypes current_game;
    
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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
