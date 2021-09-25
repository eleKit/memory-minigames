using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryLevelSelector : MonoBehaviour
{
    public Sprite[] animalSprites;
    public Sprite[] emojiSprites;
    public Sprite[] itemsSprites;
    public Sprite[] chibiSprites;
    public Sprite[] lettersSprites;
    
    private MemoryStandardLevels levels = new MemoryStandardLevels();
    

    // Start is called before the first frame update
    public void SetupLevelGenerator()
    {
        levels.AddToDictionary(0, animalSprites);
        levels.AddToDictionary(1, emojiSprites);
        levels.AddToDictionary(2, itemsSprites);
        levels.AddToDictionary(3, chibiSprites);
        levels.AddToDictionary(4, lettersSprites);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Sprite> GenerateLevel(int level)
    {
        switch (level)
        {
            case 0:
                return GenerateStandardLevelArray(levels.levelAnimal1);
            case 1:
                return GenerateStandardLevelArray(levels.levelChibi1);
            case 2:
                return GenerateStandardLevelArray(levels.levelItems);
            case 3:
                return GenerateStandardLevelArray(levels.levelLetters1);
        }

        return GenerateStandardLevelArray(levels.levelChibi2);
    }

    private List<Sprite> GenerateStandardLevelArray(List<OrderedDictionary> level_dictionary)
    {
        List<Sprite> current_level_elements = new List<Sprite>();
        foreach (var v in level_dictionary)
        {
            foreach (var index in v.elements_indexes)
            {
                current_level_elements.Add(levels.levels_dictionary[v.key][index]);
            }
        }

        return current_level_elements;

    }
    
    
}
