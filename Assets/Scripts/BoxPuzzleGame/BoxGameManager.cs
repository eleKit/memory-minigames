using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BoxGameManager : MonoBehaviour
{
   private const int Grid_Dimension = 3;
   public GameObject[] colour_title_elements;
   
   public GameObject[] colour_level_elements;

   private List<int> indexes_sequence_of_elements_to_instantiate;

   public float[] y_positions;
   
   public float[] x_positions;

   public float line_vert_1_x_position;
   public float line_vert_2_x_position;
   public float line_vert_3_x_position;

   private bool[,] xy = new bool[Grid_Dimension,Grid_Dimension];

   public float x_default_position;

   public Transform current_element_transform { get; private set; }
   private DragElement current_element_drag_script;

   private int index = 0;


   private void Start()
   {
      //setup the list with sequence of boxes in order, it is repeated 3 times since the play columns are 3
      indexes_sequence_of_elements_to_instantiate = new List<int>();
      for (int i = 0; i < colour_level_elements.Length; i++)
      {
         indexes_sequence_of_elements_to_instantiate.Add(i);  
         indexes_sequence_of_elements_to_instantiate.Add(i);  
         indexes_sequence_of_elements_to_instantiate.Add(i);  
      }
      
      //randomize the elements in the list
      Random rng = new Random(); 
      int n = indexes_sequence_of_elements_to_instantiate.Count;  
      while (n > 1) {  
         n--;  
         int k = rng.Next(n + 1);  
         int value = indexes_sequence_of_elements_to_instantiate[k];  
         indexes_sequence_of_elements_to_instantiate[k] = indexes_sequence_of_elements_to_instantiate[n];  
         indexes_sequence_of_elements_to_instantiate[n] = value;  
      }
      
      //instantiate the boxes symbols in the top area cof each column
      foreach (var e in colour_title_elements)
      {
         Instantiate(e, e.transform.position, Quaternion.identity);
      }
      
      // setup the index of the indexes_sequence_of_elements_to_instantiate at 0
      index = 0;

      // instantiate the first interactable box
      IntantiateBox();   
   }

   private void Update()
   {
      
   }

   #region Buttons Functions
   
   
   /// <summary>
   /// This function is called by arrow buttons to locate a box
   /// </summary>
   /// <param name="x_index">index of the button pressed</param>
   public void SetPositionOfCurrentElement(int x_index)
   {
      ResetIndexes(current_element_drag_script.x_grid_index_current, current_element_drag_script.y_grid_index_current);
      bool done = false;
      for (int y_index = 0; y_index < Grid_Dimension; y_index++)
      {
         if (!xy[x_index, y_index])
         {
            xy[x_index, y_index] = true;
            current_element_transform.position = new Vector3(x_positions[x_index], y_positions[y_index], 0f);
            current_element_drag_script.x_grid_index_current = x_index;
            current_element_drag_script.y_grid_index_current = y_index;
            done = true;
            break;
         }
      }
      if(!done)
         Debug.LogError("the column x_index is full");
   }

   #endregion
   
   #region On Mouse Up Functions
   
   public void SetPositionBasedOnVector3(Transform t)
   {
      //current_section = go_on ? PlazaSections.part1 : PlazaSections.init
      float x_index = 0f;

      if (t.position.x < line_vert_1_x_position)
      {
         ResetIndexes(current_element_drag_script.x_grid_index_current, current_element_drag_script.y_grid_index_current);
         t.position = new Vector3(x_default_position, 2f, 0f);
         Debug.Log("0 cond");

      } else if (t.position.x > line_vert_1_x_position && t.position.x < line_vert_2_x_position)
      {
         SetPositionOfCurrentElement(0);
         Debug.Log("1 cond");
      } else if (t.position.x > line_vert_2_x_position && t.position.x < line_vert_3_x_position)
      {
         SetPositionOfCurrentElement(1);
         Debug.Log("2 cond");
      } else if (t.position.x > line_vert_3_x_position)
      {
         SetPositionOfCurrentElement(2);
         Debug.Log("3 cond");
      }


   }
   
   #endregion

   #region Common Functions

   
   /// <summary>
   /// This function is called on mouse click on a box
   /// </summary>
   /// <param name="t">transform of the box clicked</param>
   public void SetCurrentTransform(Transform t)
   {
      current_element_transform = t;
      current_element_drag_script = t.gameObject.GetComponent<DragElement>();
      Debug.Log(current_element_drag_script.x_grid_index_current + " , " + current_element_drag_script.y_grid_index_current);
   }

   /// <summary>
   /// Private, use this to reset xy matrix indexes
   /// </summary>
   /// <param name="x_index"></param>
   /// <param name="y_index"></param>
   private void ResetIndexes(int x_index, int y_index)
   {
      if(!(x_index == -1 && y_index == -1))
         xy[x_index, y_index] = false;
   }
   
   #endregion

   #region Instantiate Functions
   

   /// <summary>
   /// Private, use this to instantiate a new box with random colour
   /// </summary>
   private void IntantiateBox()
   {
      GameObject go = Instantiate(colour_level_elements[indexes_sequence_of_elements_to_instantiate[index]], new Vector3(x_default_position, 0f, 0f),
         Quaternion.identity);
      current_element_drag_script = go.GetComponent<DragElement>();
      current_element_transform = go.transform;     
   }
   


/// <summary>
/// Public, use this to instantiate the nex interactable box in the play
/// </summary>
   public void InstantiateNext()
   {
      index++;
      if (index < indexes_sequence_of_elements_to_instantiate.Count)
      {
         IntantiateBox();
      }
   }
   
#endregion
   
}
