using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] balls_title_array;
   public GameObject[] balls_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] sqares_title_array;
   public GameObject[] sqares_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] heart_title_array;
   public GameObject[] heart_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] stars_title_array;
   public GameObject[] stars_array;
   [Header("you MUST choose the same order for title and interactable arrays")]
   public GameObject[] others_title_array;
   public GameObject[] others_array;

   public LevelElements[] current_level_elements{ get; private set; }
   private int[] indexes_of_elements;

   public class LevelElements
   {
      public GameObject title_element;
      public GameObject interacting_element;

   }

   public void GenerateLevel(int level)
   {
      switch (level){
         case 0:
            BallsLevel();
            current_level_elements = new LevelElements[indexes_of_elements.Length];
            for (int i=0; i< indexes_of_elements.Length; i++)
            {
               current_level_elements[i] = new LevelElements
               {
                  title_element = balls_title_array[indexes_of_elements[i]],
                  interacting_element = balls_array[indexes_of_elements[i]]
               };
            }
            break;
      }

     
   }

   public LevelElements GetCurrentLevelElement(int index)
   {
      return current_level_elements[index];
   }
   

   public void BallsLevel()
   {
      int i = Random.Range(0, balls_array.Length);
      int j = 0;
      do
      {
         j = Random.Range(0, balls_array.Length);
      } while (j==i);
      
      int k = 0;
      do
      {
         k = Random.Range(0, balls_array.Length);
      } while (k==i || k ==j);
      
      indexes_of_elements = new []{i,j,k};

   }


   
   
   
   
}
