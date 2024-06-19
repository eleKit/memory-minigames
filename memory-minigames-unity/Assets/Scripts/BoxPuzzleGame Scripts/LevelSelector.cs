using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
   private const int N_of_arrays = 5;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] balls_title_array;
   public GameObject[] balls_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] squares_title_array;
   public GameObject[] squares_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] heart_title_array;
   public GameObject[] heart_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] stars_title_array;
   public GameObject[] stars_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] others_title_array;
   public GameObject[] others_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] letters_title_array;
   public GameObject[] letters_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] faces_title_array;
   public GameObject[] faces_array;
    


   public List<LevelElements> current_level_elements{ get; private set; }

   private BoxesStandardLevels standard_levels = new BoxesStandardLevels();

   public class LevelElements
   {
      public GameObject title_element;
      public GameObject interacting_element;

   }

   public void SetupLevelGenerator()
   {
      current_level_elements = new List<LevelElements>();
      standard_levels.AddToDictionary(0, balls_title_array, balls_array);
      standard_levels.AddToDictionary(1, squares_title_array, squares_array);
      standard_levels.AddToDictionary(2, heart_title_array, heart_array);
      standard_levels.AddToDictionary(3, stars_title_array, stars_array);
      standard_levels.AddToDictionary(4, others_title_array, others_array);
      standard_levels.AddToDictionary(5, letters_title_array, letters_array);
      standard_levels.AddToDictionary(6, faces_title_array, faces_array);
      
   }
   
   
   public LevelElements GetCurrentLevelElement(int index)
   {
      return current_level_elements[index];
   }
   
   
   #region Standard Single-Multiple Level
   
   public void GenerateStaticLevel(int level)
   {
      switch (level){
         case -3:
            GenerateStandardLevelArray(standard_levels.levelA);
            break;
         case -2:
            GenerateStandardLevelArray(standard_levels.levelB);
            break;
         case -1:
            GenerateStandardLevelArray(standard_levels.levelC);
            break;
         case 0:
            GenerateStandardLevelArray(standard_levels.level0);
            break;
         case 1:
            GenerateStandardLevelArray(standard_levels.level1);
            break;
         case 2:
            GenerateStandardLevelArray(standard_levels.level2);
            break;
         case 3:
            GenerateStandardLevelArray(standard_levels.level3);
            break;
         case 4:
            GenerateStandardLevelArray(standard_levels.level4);
            break;
         case 5:
            GenerateStandardLevelArray(standard_levels.level5);
            break;
         case 6:
            GenerateStandardLevelArray(standard_levels.level6);
            break;
         case 7:
            GenerateStandardLevelArray(standard_levels.level7);
            break;
         case 8:
            GenerateStandardLevelArray(standard_levels.level8);
            break;
         case 10:
            GenerateStandardLevelArray(standard_levels.levelABC);
            break;
         case 11:
            GenerateStandardLevelArray(standard_levels.levelDEF);
            break;
         case 12:
            GenerateStandardLevelArray(standard_levels.levelGHI);
            break;
         case 13:
            GenerateStandardLevelArray(standard_levels.levelJKL);
            break;
         case 14:
            GenerateStandardLevelArray(standard_levels.levelMNO);
            break;
         case 15:
            GenerateStandardLevelArray(standard_levels.levelPQR);
            break;
         case 16:
            GenerateStandardLevelArray(standard_levels.levelSTU);
            break;
         case 17:
            GenerateStandardLevelArray(standard_levels.levelVWX);
            break;
         case 18:
            GenerateStandardLevelArray(standard_levels.levelXYZ);
            break;
         case 19:
            GenerateStandardLevelArray(standard_levels.levelF1);
            break;
         case 20:
            GenerateStandardLevelArray(standard_levels.levelF2);
            break;
         case 21:
            GenerateStandardLevelArray(standard_levels.levelF3);
            break;
         case 22:
            GenerateStandardLevelArray(standard_levels.levelF4);
            break;

      }
      
   }

   private void GenerateStandardLevelArray(List<OrderedDictionary> level_dictionary)
   {
      current_level_elements.Clear();
      foreach (var v in level_dictionary)
      {
         foreach (var index in v.elements_indexes)
         {
            current_level_elements.Add(new LevelElements
            {
               title_element = standard_levels.go_dictionary[v.key].title_array[index],
               interacting_element = standard_levels.go_dictionary[v.key].interactable_array[index]
            });
         }
      }
   }

   #endregion

   #region Single Random Level
   
   public void GenerateRandomSingleLevel(int level)
   {
      switch (level){
         case 0:
            RandomSingleLevelArray(balls_title_array, balls_array);
            break;
         case 1:
            RandomSingleLevelArray(squares_title_array, squares_array);
            break;
         case 2:
            RandomSingleLevelArray(heart_title_array, heart_array);
            break;
         case 3:
            RandomSingleLevelArray(stars_title_array, stars_array);
            break;
         case 4:
            RandomSingleLevelArray(others_title_array, others_array);
            break;
         case 5:
            RandomSingleLevelArray(letters_title_array, letters_array);
            break;
         case 6:
            RandomSingleLevelArray(faces_title_array, faces_array);
            break;
      }
      
   }
   
   private void RandomSingleLevelArray(GameObject[] go_title_array, GameObject[] go_array)
   {
      var indexes_of_elements = ExtractLevelIndexes(go_array);
      current_level_elements.Clear();
      for (int i=0; i< indexes_of_elements.Length; i++)
      {
         current_level_elements.Add(new LevelElements
         {
            title_element = go_title_array[indexes_of_elements[i]],
            interacting_element = go_array[indexes_of_elements[i]]
         });
      }
   }
   
   private int[] ExtractLevelIndexes(GameObject[] go_array)
   {
      int i = Random.Range(0, go_array.Length);
      int j = 0;
      do
      {
         j = Random.Range(0, go_array.Length);
      } while (j==i);
      
      int k = 0;
      do
      {
         k = Random.Range(0, go_array.Length);
      } while (k==i || k ==j);
      
      return new []{i,j,k};

   }
   
   #endregion


   
   
   
   
}
