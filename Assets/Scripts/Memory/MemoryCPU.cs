using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCPU : MonoBehaviour
{
    private const int NUMBER_OF_CARDS = 11;
    private MemoryCPUUpdater cpu_UPDATER;
    private MemoryManager memoryManager;

    private MemoryCPUFlippedCard currentFlippedCard;

    
    // Start is called before the first frame update
    void Start()
    {
        memoryManager = GameObject.FindGameObjectWithTag("memoryManager").GetComponent<MemoryManager>();
        cpu_UPDATER = GameObject.FindGameObjectWithTag("memoryCPUupdater").GetComponent<MemoryCPUUpdater>();
        currentFlippedCard = null;
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
       /* var length = cpu_UPDATER.indexesOfSpritesAlreadySeen.Count;
        if(length > 0)
        {
            currentFlippedCard =
                memoryManager.FlipCardAgent(cpu_UPDATER.indexesOfSpritesAlreadySeen.Dequeue());
        }
        else
        {
            ExecuteFirstRandomAction();
        }     */
    }

    public void ExecuteSecondSuccessActionIfPossible()
    {
        if (cpu_UPDATER.cardButtonsInverseDictionary.ContainsKey(currentFlippedCard.s))
        {
            memoryManager.FlipCardAgent(cpu_UPDATER.cardButtonsInverseDictionary[currentFlippedCard.s]);
        }
        else
        {
            ExecuteSecondRandomAction();
        }
    }

    public void ExecuteSecondRandomAction()
    {
        var tmp_index = Random.Range(0,NUMBER_OF_CARDS +1);
        while (tmp_index == currentFlippedCard.index)
        {
            tmp_index = Random.Range(0,NUMBER_OF_CARDS +1);
        }
        memoryManager.FlipCardAgent(tmp_index);
    }
}
