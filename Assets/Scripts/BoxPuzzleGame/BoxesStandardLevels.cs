using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesStandardLevels
{
    public class TitleAndInteractableArrays
    {
        public GameObject[] title_array;
        public GameObject[] interactable_array;
    }

    public class OrderedDictionary
    {
        public int key;
        public int[] elements_indexes;
    }
    
    public List<OrderedDictionary> level0 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0}},
        new OrderedDictionary() {key = 1, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 0, elements_indexes = new[] {2}},
    };

    public List<int[]> level1;
    public List<int[]> level2;
    public List<int[]> level3;
    public List<int[]> level4;
    public List<int[]> level5;
    public List<int[]> level6;
    public List<int[]> level7;
    public List<int[]> level8;
    public List<int[]> level9;

    public Dictionary<int, TitleAndInteractableArrays > go_dictionary = new Dictionary<int, TitleAndInteractableArrays>();

    public void AddToDictionary(int key, GameObject[] title_array, GameObject[] interactable_array)
    {
        go_dictionary.Add(key, new TitleAndInteractableArrays{title_array = title_array, interactable_array = interactable_array});
    }
    
}
