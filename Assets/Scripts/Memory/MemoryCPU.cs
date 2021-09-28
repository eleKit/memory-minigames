using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCPU : MonoBehaviour
{
    private const int NUMBER_OF_CARDS = 11;
    private MemoryCPUUpdater cpu_UPDATER;
    private MemoryManager memoryManager;

    private MemoryCPUFlippedCard card;

    
    // Start is called before the first frame update
    void Start()
    {
        memoryManager = GameObject.FindGameObjectWithTag("memoryManager").GetComponent<MemoryManager>();
        cpu_UPDATER = GameObject.FindGameObjectWithTag("memoryCPUupdater").GetComponent<MemoryCPUUpdater>();
        card = new MemoryCPUFlippedCard(null, 0, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteFirstRandomAction()
    {
       memoryManager.FlipCardAgent(Random.Range(0,NUMBER_OF_CARDS +1));
    }

    public void ExecuteFirstReasonedAction()
    {
        card = cpu_UPDATER.GetFirstSeenCard();
        Debug.Log("first index action" + card.index);
        if(!card.ERROR_CARD) 
        {memoryManager.FlipCardAgent(card.index);}
        else
        {
            ExecuteFirstRandomAction();
        }
    }

    public void ExecuteSecondSuccessActionIfPossible()
    {
        Debug.Log("second index possible action" + card.other_index + "\n" + "is seen? " + cpu_UPDATER.CheckIfSecondIsSeen(card));
        if(cpu_UPDATER.CheckIfSecondIsSeen(card))
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
        while (tmp_index == card.index)
        {
            tmp_index = Random.Range(0,NUMBER_OF_CARDS +1);
        }
        memoryManager.FlipCardAgent(tmp_index);
    }
}
