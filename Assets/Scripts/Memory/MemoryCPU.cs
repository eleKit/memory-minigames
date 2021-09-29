using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCPU : MonoBehaviour
{
    private const int NUMBER_OF_CARDS = 11;
    private MemoryDataManager memoryDataManager;
    private MemoryManager memoryManager;

    private MemoryCard card;

    
    // Start is called before the first frame update
    void Start()
    {
        memoryManager = GameObject.FindGameObjectWithTag("memoryManager").GetComponent<MemoryManager>();
        memoryDataManager = GameObject.FindGameObjectWithTag("memoryCPUupdater").GetComponent<MemoryDataManager>();
        card = new MemoryCard( 0, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteFirstRandomAction()
    {
        var tmp_index = Random.Range(0,NUMBER_OF_CARDS +1);
        while (memoryDataManager.GetCardAtIndex(tmp_index).won)
        {
            tmp_index = Random.Range(0,NUMBER_OF_CARDS +1);
        }
        memoryManager.FlipCardAgent(Random.Range(0, NUMBER_OF_CARDS + 1));

    }

    public void ExecuteFirstReasonedAction()
    {
        card = memoryDataManager.GetFirstSeenCard();
//        Debug.Log("first index action" + card.index);
        if(!card.ERROR_CARD) 
        {memoryManager.FlipCardAgent(card.index);}
        else
        {
            ExecuteFirstRandomAction();
        }
    }

    public void ExecuteSecondSuccessActionIfPossible()
    {
        //Debug.Log("second index possible action" + card.other_index + "\n" + "is seen? " + cpu_UPDATER.CheckIfSecondIsSeen(card));
        if(memoryDataManager.CheckIfSecondIsSeen(card))
        {
            memoryManager.FlipCardAgent(card.other_index);
        }
        else
        {
            ExecuteSecondRandomAction();
        }
    }

    public void ExecuteSecondRandomAction()
    {
        var tmp_index = Random.Range(0,NUMBER_OF_CARDS +1);
        while (tmp_index == card.index || memoryDataManager.GetCardAtIndex(tmp_index).won)
        {
            tmp_index = Random.Range(0,NUMBER_OF_CARDS +1);
        }
        memoryManager.FlipCardAgent(tmp_index);
    }
}
