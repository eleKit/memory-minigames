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
    public Sprite[] facesSprites;
    
    private MemoryStandardLevels levels = new MemoryStandardLevels();
    

    // Start is called before the first frame update
    public void SetupLevelGenerator()
    {
        levels.AddToDictionary(0, animalSprites);
        levels.AddToDictionary(1, emojiSprites);
        levels.AddToDictionary(2, itemsSprites);
        levels.AddToDictionary(3, chibiSprites);
        levels.AddToDictionary(4, lettersSprites);
        levels.AddToDictionary(5, facesSprites);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Sprite> GenerateLevel(string level)
    {
        switch (level)
        {
            case "A1":
                return GenerateStandardLevelArray(levels.levelAnimal1);
            case "A2":
                return GenerateStandardLevelArray(levels.levelAnimal2);
            case "A3":
                return GenerateStandardLevelArray(levels.levelAnimal3);
            case "A4":
                return GenerateStandardLevelArray(levels.levelAnimal4);
            case "A5":
                return GenerateStandardLevelArray(levels.levelAnimal5);
            case "E":
                return GenerateStandardLevelArray(levels.levelEmoji);
            case "I":
                return GenerateStandardLevelArray(levels.levelItems);
            case "C1":
                return GenerateStandardLevelArray(levels.levelChibi1);
            case "C2":
                return GenerateStandardLevelArray(levels.levelChibi2);
            case "C3":
                return GenerateStandardLevelArray(levels.levelChibi3);
            case "C4":
                return GenerateStandardLevelArray(levels.levelChibi4);
            case "L1":
                return GenerateStandardLevelArray(levels.levelLetters1);
            case "L2":
                return GenerateStandardLevelArray(levels.levelLetters2);
            case "L3":
                return GenerateStandardLevelArray(levels.levelLetters3);
            case "L4":
                return GenerateStandardLevelArray(levels.levelLetters4);
            case "F1":
                return GenerateStandardLevelArray(levels.levelFaces1);
            case "F2":
                return GenerateStandardLevelArray(levels.levelFaces2);
            case "F3":
                return GenerateStandardLevelArray(levels.levelFaces3);
            case "F4":
                return GenerateStandardLevelArray(levels.levelFaces4);
            case "F5":
                return GenerateStandardLevelArray(levels.levelFaces5);
            
            
        }

        return GenerateStandardLevelArray(levels.levelAnimal1);
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
