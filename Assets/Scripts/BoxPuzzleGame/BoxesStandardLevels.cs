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
    
    public List<OrderedDictionary> level2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {0}},
        new OrderedDictionary() {key = 0, elements_indexes = new[] {2, 0}},
    };

    public List<OrderedDictionary> level9 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 1, elements_indexes = new[] {2}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {3}},
    };
    public List<OrderedDictionary> level3 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0}},
        new OrderedDictionary() {key = 2, elements_indexes = new[] {3}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {4}},
    };
    public List<OrderedDictionary> level0 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {3}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 1, elements_indexes = new[] {5}},
    };
    public List<OrderedDictionary> level4 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {3}},
        new OrderedDictionary() {key = 0, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 4, elements_indexes = new[] {5}},
    };
    public List<OrderedDictionary> level5 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0}},
        new OrderedDictionary() {key = 4, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 0, elements_indexes = new[] {2}},
    };
    public List<OrderedDictionary> level6 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {5}},
        new OrderedDictionary() {key = 4, elements_indexes = new[] {6}},
        new OrderedDictionary() {key = 1, elements_indexes = new[] {2}},
    };
    public List<OrderedDictionary> level7 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {5}},
        new OrderedDictionary() {key = 2, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {3}},
    };
    public List<OrderedDictionary> level1 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 2, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {4}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {1}}
    };
    public List<OrderedDictionary> level8 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {4}},
        new OrderedDictionary() {key = 1, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 4, elements_indexes = new[] {0}},
    };

    public Dictionary<int, TitleAndInteractableArrays > go_dictionary = new Dictionary<int, TitleAndInteractableArrays>();

    public void AddToDictionary(int key, GameObject[] title_array, GameObject[] interactable_array)
    {
        go_dictionary.Add(key, new TitleAndInteractableArrays{title_array = title_array, interactable_array = interactable_array});
    }
    
}
