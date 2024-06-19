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

    public List<OrderedDictionary> levelA = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0, 1, 2}},
    };
    
    public List<OrderedDictionary> levelB = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {0, 2, 4}},
    };
    
    public List<OrderedDictionary> levelC = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 3, elements_indexes = new[] {0, 3, 4}},
    };
    
    public List<OrderedDictionary> level0 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0}},
        new OrderedDictionary() {key = 2, elements_indexes = new[] {3}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {4}},
    };
    
    public List<OrderedDictionary> level1 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {4}},
    };
    
    public List<OrderedDictionary> level2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {0}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {4}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {1}}
    };

    public List<OrderedDictionary> level3 = new List<OrderedDictionary>()
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
        new OrderedDictionary() {key = 2, elements_indexes = new[] {2}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {3}},
    };
   
    public List<OrderedDictionary> level8 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {4}},
        new OrderedDictionary() {key = 1, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 4, elements_indexes = new[] {0}},
    };
    
    public List<OrderedDictionary> level9 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {1}},
        new OrderedDictionary() {key = 1, elements_indexes = new[] {2}},
        new OrderedDictionary() {key = 3, elements_indexes = new[] {3}},
    };
    
    #region Letters
    
    public List<OrderedDictionary> levelABC = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {0, 1, 2}},
    };
    
    public List<OrderedDictionary> levelDEF = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {3, 4, 5}},
    };
    
    public List<OrderedDictionary> levelGHI = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {6, 7, 8}},
    };
    
    public List<OrderedDictionary> levelJKL = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {9, 10, 11}},
    };
    
    public List<OrderedDictionary> levelMNO = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {12, 13, 14}},
    };
    
    public List<OrderedDictionary> levelPQR = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {15, 16, 17}},
    };
    
    public List<OrderedDictionary> levelSTU = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {18, 19, 20}},
    };
    
    public List<OrderedDictionary> levelVWX = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {21, 22, 23}},
    };
    
    public List<OrderedDictionary> levelXYZ = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {23, 24, 25}},
    };
    
    public List<OrderedDictionary> levelF1 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 6, elements_indexes = new[] {0, 10, 17}}, //angry, happy, cry
    };
    
    
    public List<OrderedDictionary> levelF2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 6, elements_indexes = new[] {16, 4, 14}}, //disappointed, happy, disgusted
    };

    
    public List<OrderedDictionary> levelF3 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 6, elements_indexes = new[] {8, 6, 19}}, //angry2, sad, joy
    };
    
    public List<OrderedDictionary> levelF4 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 6, elements_indexes = new[] {20, 4, 9}}, //disappointed, joy, cry
    };

    #endregion
    

    public Dictionary<int, TitleAndInteractableArrays > go_dictionary = new Dictionary<int, TitleAndInteractableArrays>();

    public void AddToDictionary(int key, GameObject[] title_array, GameObject[] interactable_array)
    {
        go_dictionary.Add(key, new TitleAndInteractableArrays{title_array = title_array, interactable_array = interactable_array});
    }
    
}
