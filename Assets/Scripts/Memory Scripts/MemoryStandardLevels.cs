using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryStandardLevels
{
    public Dictionary<int, Sprite[]> levels_dictionary = new Dictionary<int, Sprite[]>();
    
    public void AddToDictionary(int key, Sprite[] sprites_array)
    {
        levels_dictionary.Add(key, sprites_array);
    }

    public List<OrderedDictionary> levelAnimal1 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {2, 3, 4, 7, 9, 10}}, //{0, 1, 3, 4, 5, 7}},
    };

    public List<OrderedDictionary> levelAnimal2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0, 5, 12, 14, 16, 17}}, //{1, 3, 5, 7, 9, 11}},
    };
    
    public List<OrderedDictionary> levelAnimal3 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {3, 4, 12, 13, 15, 17 }}, //{5, 6,  10, 11, 12, 14}},
    };
    
    
    public List<OrderedDictionary> levelAnimal4 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0, 1, 5, 6, 11, 14}}, //{2, 3, 4, 8, 12, 13}},
    };
    
    public List<OrderedDictionary> levelAnimal5 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0, 5, 8, 11, 12, 14}},
    };
    
    public List<OrderedDictionary> levelEmoji = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 1, elements_indexes = new[] {0, 1, 2, 3, 4, 5}},
    };
    
    public List<OrderedDictionary> levelItems = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 2, elements_indexes = new[] {0, 1, 2, 3, 4, 5}},
    };
    
    public List<OrderedDictionary> levelChibi1 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 3, elements_indexes = new[] {0, 1, 2, 4, 5, 6}},
    };
    
    public List<OrderedDictionary> levelChibi2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 3, elements_indexes = new[] {7, 8, 9, 10, 11, 12}},
    };
    
    public List<OrderedDictionary> levelChibi3 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 3, elements_indexes = new[] {1, 3, 5, 7, 11, 13}},
    };
    
    public List<OrderedDictionary> levelChibi4 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 3, elements_indexes = new[] {0, 2, 8, 10, 12, 14}},
    };
    
    
    public List<OrderedDictionary> levelLetters1 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {0, 1, 2, 3, 4, 5}},
    };
    
    public List<OrderedDictionary> levelLetters2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {6, 7, 8, 9, 10, 11}},
    };
    
    public List<OrderedDictionary> levelLetters3 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {12, 13, 14, 15, 16, 17}},
    };
    
    public List<OrderedDictionary> levelLetters4 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {18, 19, 20, 21, 22, 23}},
    };
    
    public List<OrderedDictionary> levelLetters5 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 4, elements_indexes = new[] {24, 25, 0, 1, 2, 3}},
    };
    
    public List<OrderedDictionary> levelFaces1 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {0, 7, 8, 11, 14, 19 }},
    };
    
    public List<OrderedDictionary> levelFaces2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {1, 2, 10, 12, 15, 20 }},
    };
    
    public List<OrderedDictionary> levelFaces3 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {3, 4, 5, 13, 14, 27 }},
    };
    
    public List<OrderedDictionary> levelFaces4 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {6, 9, 16, 17, 25, 26 }},
    };
    
    public List<OrderedDictionary> levelFaces5 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 5, elements_indexes = new[] {2, 11, 18, 21, 23, 24}},
    };

    
    
    
    
    
    
    



}
