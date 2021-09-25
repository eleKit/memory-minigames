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
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0, 1, 2, 4, 5, 6}},
    };
    
    public List<OrderedDictionary> levelAnimal2 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {7, 8, 9, 10, 11, 12}},
    };
    
    public List<OrderedDictionary> levelAnimal3 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {1, 3, 5, 7, 11, 13}},
    };
    
    public List<OrderedDictionary> levelAnimal4 = new List<OrderedDictionary>()
    {
        new OrderedDictionary() {key = 0, elements_indexes = new[] {0, 2, 8, 10, 12, 14}},
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

    
    
    
    
    
    
    



}
