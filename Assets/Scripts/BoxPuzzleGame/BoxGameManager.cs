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

   private bool[,] xy = new bool[Grid_Dimension,Grid_Dimension];

   public float x_default_position;

   private List<GameObject> elements_to_instantiate;

   public Transform current_element_transform { get; private set; }
   private DragElement current_element_drag_script;

   private int index = 0;

   private bool reset_performed = false;


   private void Start()
   {
      indexes_sequence_of_elements_to_instantiate = new List<int>();
      for (int i = 0; i < colour_level_elements.Length; i++)
      {
         indexes_sequence_of_elements_to_instantiate.Add(i);  
         indexes_sequence_of_elements_to_instantiate.Add(i);  
         indexes_sequence_of_elements_to_instantiate.Add(i);  
      }
      
      Random rng = new Random(); 
      int n = indexes_sequence_of_elements_to_instantiate.Count;  
      while (n > 1) {  
         n--;  
         int k = rng.Next(n + 1);  
         int value = indexes_sequence_of_elements_to_instantiate[k];  
         indexes_sequence_of_elements_to_instantiate[k] = indexes_sequence_of_elements_to_instantiate[n];  
         indexes_sequence_of_elements_to_instantiate[n] = value;  
      }
      foreach (var e in colour_title_elements)
      {
         Instantiate(e, e.transform.position, Quaternion.identity);
      }
      
      index = 0;

      GameObject go = Instantiate(colour_level_elements[index], new Vector3(x_default_position, 0f, 0f),
         Quaternion.identity);
      current_element_drag_script = go.GetComponent<DragElement>();
      current_element_transform = go.transform;   }

   private void Update()
   {
      
   }


   /*
    public void SetPositionOfCurrentElement(float x_coord)
   {
      if (index < y_positions.Length)
      {
         current_element_transform.position = new Vector3(x_coord, y_positions[index], 0f);
      }
   }
   */
   
   public void SetPositionOfCurrentElement(int x_index)
   {
      reset_performed = false;
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

   public void SetCurrentTransform(Transform t)
   {
      current_element_transform = t;
      current_element_drag_script = t.gameObject.GetComponent<DragElement>();
      ResetIndexes(current_element_drag_script.x_grid_index_current, current_element_drag_script.y_grid_index_current);
      reset_performed = true;
   }

   private void ResetIndexes(int x_index, int y_index)
   {
      xy[x_index, y_index] = false;
   }
   
   


   public void InstantiateNext()
   {
      if (reset_performed)
      {
         SetPositionOfCurrentElement(current_element_drag_script.x_grid_index_current);
      }
      index++;
      if (index >= y_positions.Length)
      {
         index = 0;
      }

      GameObject go = Instantiate(colour_level_elements[index], new Vector3(x_default_position, 0f, 0f),
         Quaternion.identity);
      current_element_drag_script = go.GetComponent<DragElement>();
      current_element_transform = go.transform;
   }
   
   
   
}
