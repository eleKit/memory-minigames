
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class MemoryManager : MonoBehaviour
{
    public Sprite[] testSprites;

    public GameObject cardToInstantiate;

    private List<GameObject> cardsInstantiated;

    public int flipped = 0;

    private Vector3[] cardsPositions =
    {
        new Vector3(-6.44f, 3.25f, 0f), new Vector3(-3.32f, 3.25f, 0f), new Vector3(-0.36f, 3.25f, 0f), new Vector3(2.76f, 3.25f, 0f),
        new Vector3(-6.44f, 0.14f, 0f), new Vector3(-3.32f, 0.14f, 0f), new Vector3(-0.36f, 0.14f, 0f), new Vector3(2.76f, 0.14f, 0f),
        new Vector3(-6.44f, -3.11f, 0f), new Vector3(-3.32f, -3.11f, 0f), new Vector3(-0.36f, -3.11f, 0f), new Vector3(2.76f, -3.11f, 0f),
    };




    // Start is called before the first frame update
    void Start()
    {
        cardsInstantiated = new List<GameObject>();
        SetupGame();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void ShuffleList<T>(List<T> l)
    {
        System.Random rng = new System.Random();
        int n = l.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = l[k];
            l[k] = l[n];
            l[n] = value;

        }

    }

    void SetupGame()
    {
        List<int> indexes = new List<int>();
        for (int j = 0; j < cardsPositions.Length; j++)
        {
            indexes.Add(j);
        }

        ShuffleList(indexes);
        
        int keyOfIndexes = 0;

        foreach (var sprite in testSprites)
        {
            for (int j=0; j< 2; j++)
            {
                GameObject newObj = Instantiate(cardToInstantiate, cardsPositions[indexes[keyOfIndexes]], Quaternion.identity);
                newObj.GetComponent<Image>();
                cardsInstantiated.Add(newObj);
                keyOfIndexes++;
            }
        }
    }
}
