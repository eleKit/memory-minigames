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
    
    
    void OnEnable() {
        EventManager.StartListening("activateTurnCPU", ActivateCPUActions);
    }

    void OnDisable() {
        EventManager.StopListening("activateTurnCPU", ActivateCPUActions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExecuteFirstRandomAction()
    {
        List<int> tmp_list = new List<int>(memoryDataManager.notWonCards.Keys);
        var tmp_index = Random.Range(0,tmp_list.Count);
        card = memoryDataManager.notWonCards[tmp_list[tmp_index]];
        memoryManager.FlipCardAgent(tmp_list[tmp_index]);

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

    private void ExecuteSecondRandomAction()
    {
        List<int> tmp_list = new List<int>(memoryDataManager.notWonCards.Keys);
        var tmp_index = Random.Range(0,tmp_list.Count);
        while (tmp_list[tmp_index] == card.index)
        {
            tmp_index = Random.Range(0,tmp_list.Count);
        }
        memoryManager.FlipCardAgent(tmp_list[tmp_index]);
    }

    private void ActivateCPUActions(Dictionary<string, object> action)
    {
        StartCoroutine(ExecuteActions());
    }

    IEnumerator ExecuteActions()
    {
        int value = Random.Range(0, 2);
        switch (value)
        {
            case 0:
                ExecuteFirstRandomAction();
                break;
            case 1:
                ExecuteFirstReasonedAction();
                break;
        }

        yield return new WaitForSeconds(2f);
        
        value = Random.Range(0, 2);
        Debug.Log(value);
        switch (value)
        {
            case 0:
                ExecuteSecondRandomAction();
                break;
            case 1:
                ExecuteSecondSuccessActionIfPossible();
                break;
        }
    }
    
}
