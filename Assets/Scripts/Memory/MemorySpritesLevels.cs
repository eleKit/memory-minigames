using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorySpritesLevels : MonoBehaviour
{
    public Sprite[] animalSprites;
    public Sprite[] emojiSprites;
    public Sprite[] itemsSprites;
    public Sprite[] chibiSprites;
    public Sprite[] lettersSprites;

    private Dictionary<int, Sprite[]> levels_dictionary;

    private Sprite[] current_level_elements;

    // Start is called before the first frame update
    void Start()
    {
        levels_dictionary = new Dictionary<int, Sprite[]>();
        
        levels_dictionary.Add(0, animalSprites);
        levels_dictionary.Add(1, emojiSprites);
        levels_dictionary.Add(2, itemsSprites);
        levels_dictionary.Add(3, chibiSprites);
        levels_dictionary.Add(4, lettersSprites);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateLevel(int level)
    {
        switch (level)
        {
            case 0:
                break;
        }
    }

    private void GenerateStandardLevelArray()
    {
        
    }
}
