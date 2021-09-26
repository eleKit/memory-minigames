using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCPU : MonoBehaviour
{
    private MemoryManager memoryManager;
    // Start is called before the first frame update
    void Start()
    {
        memoryManager = GameObject.FindGameObjectWithTag("memoryManager").GetComponent<MemoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
