using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCPU : MonoBehaviour
{
    private MemoryManager memoryManager;

    private Sprite currentFlippedSprite;
    // Start is called before the first frame update
    void Start()
    {
        memoryManager = GameObject.FindGameObjectWithTag("memoryManager").GetComponent<MemoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteFirstRandomAction()
    {
        memoryManager.FlipCardAgent(Random.Range(0,13));
        //currentFlippedSprite = memoryManager.c
    }
}
