using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGameManager : MonoBehaviour
{
   public GameObject[] colour_title_elements;
   
   public GameObject[] colour_level_elements;

   public float[] y_positions;

   public float x_default_position;

   private List<GameObject> elements_to_instantiate;

   private Transform current_element_transform;

   private int index = 0;
   


   private void Start()
   {
      foreach (var e in colour_title_elements)
      {
         Instantiate(e, e.transform.position, Quaternion.identity);
      }

      index = 0;

      current_element_transform = Instantiate(colour_level_elements[index], new Vector3(x_default_position, 0f, 0f), Quaternion.identity).transform;
   }

   private void Update()
   {
      
   }


   public void SetPositionOfCurrentElement(float x_coord)
   {
      if (index < y_positions.Length)
      {
         current_element_transform.position = new Vector3(x_coord, y_positions[index], 0f);
      }
   }

   public void SetCurrentTransform(Transform t)
   {
      current_element_transform = t;
   }


   public void InstantiateNext()
   {
      index++;
      if (index >= y_positions.Length)
      {
         index = 0;
      }
      current_element_transform = Instantiate(colour_level_elements[index], new Vector3(x_default_position, 0f, 0f),
         Quaternion.identity).transform;
   }
   
   
   
}
