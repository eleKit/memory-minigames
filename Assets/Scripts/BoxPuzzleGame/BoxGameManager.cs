using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;
using Rnd = UnityEngine.Random;

public class BoxGameManager : MonoBehaviour
{
   private const int Grid_Dimension = 3;

   private const int Elements_in_Grid = 9;

   /*public GameObject[] colour_title_elements;
   
   
   public GameObject[] colour_level_elements;
*/
   private List<int> indexes_sequence_of_elements_to_instantiate;


   public LevelSelector level_selector;

   public float y_title_position;
   public float[] y_positions;

   public float[] x_positions;

   public float line_vert_1_x_position;
   public float line_vert_2_x_position;
   public float line_vert_3_x_position;

   private bool[,] xy = new bool[Grid_Dimension, Grid_Dimension];
   private Sprite[,] xy_sprites = new Sprite[Grid_Dimension, Grid_Dimension];

   public Sprite[] title_sprites {get; private set;}

   public float x_default_position;
   public float y_default_position;

   public Transform current_element_transform { get; private set; } //value used by hand mouse indicator
   public SpriteRenderer current_element_sprite_renderer { get; private set; }
   private DragElement current_element_drag_script;

   public GameObject hand_mouse;

   private int index = 0;

   [Header("game canvas")] public GameObject game_canvas;
   [Header("win canvas")] public GameObject win_element;
   [Header("levels canvas")] public GameObject level_canvas;


   private void Start()
   {
      title_sprites = new Sprite[Grid_Dimension];
      indexes_sequence_of_elements_to_instantiate = new List<int>();
      level_selector.SetupLevelGenerator();
      LoadLevelSelection();
   }
   
   private void Update()
   {

   }

   public void GenerateLevel(int level)
   {
      level_selector.GenerateStaticLevel(level);
      SetupLevel();
   }

   public void GenerateRandomLevel()
   {
      int random = Rnd.Range(0, 5);
      level_selector.GenerateRandomSingleLevel(random);
      SetupLevel();
   }

   private void SetupLevel()
   {
       LoadLeveLUI();
       
       //instantiate the boxes symbols in the top area cof each column
       for (int i = 0; i < level_selector.current_level_elements.Count; i++)
       {
          Instantiate(level_selector.GetCurrentLevelElement(i).title_element,
             new Vector3(x_positions[i], y_title_position, 0f), Quaternion.identity);
          title_sprites[i] = level_selector.GetCurrentLevelElement(i).title_element.GetComponent<SpriteRenderer>()
             .sprite;
       }
       
       //setup the list with sequence of boxes in order, it is repeated 3 times since the play columns are 3
      indexes_sequence_of_elements_to_instantiate.Clear();
      for (int i = 0; i < level_selector.current_level_elements.Count; i++)
      {
         indexes_sequence_of_elements_to_instantiate.Add(i);
         indexes_sequence_of_elements_to_instantiate.Add(i);
         indexes_sequence_of_elements_to_instantiate.Add(i);
      }

      //randomize the elements in the list
      RandomizeIndexesSequence();

      // setup the index of the indexes_sequence_of_elements_to_instantiate at 0
      index = 0;

      // instantiate the first interactable box
      IntantiateBox();
   }
   

   private void RandomizeIndexesSequence()
   {
      Random rng = new Random();
      int n = indexes_sequence_of_elements_to_instantiate.Count;
      while (n > 1)
      {
         n--;
         int k = rng.Next(n + 1);
         int value = indexes_sequence_of_elements_to_instantiate[k];
         indexes_sequence_of_elements_to_instantiate[k] = indexes_sequence_of_elements_to_instantiate[n];
         indexes_sequence_of_elements_to_instantiate[n] = value;
      }
   }

   #region Buttons Functions


   /// <summary>
   /// This function is called by arrow buttons to locate a box
   /// </summary>
   /// <param name="x_index">index of the button pressed</param>
   public void SetPositionOfCurrentElement(int x_index)
   {
      SetPositionPrivateFunction(x_index);
   }

   private bool SetPositionPrivateFunction(int x_index)
   {
      bool instantiate = ResetIndexes(current_element_drag_script.x_grid_index_current, current_element_drag_script.y_grid_index_current);
      bool done = false;
      for (int y_index = 0; y_index < Grid_Dimension; y_index++)
      {
         if (!xy[x_index, y_index])
         {
            xy[x_index, y_index] = true;
            done = true;
            xy_sprites[x_index, y_index] = current_element_sprite_renderer.sprite;
            current_element_transform.position = new Vector3(x_positions[x_index], y_positions[y_index], 0f);
            current_element_drag_script.x_grid_index_current = x_index;
            current_element_drag_script.y_grid_index_current = y_index;
            break;
         }
      }

      if (instantiate && done)
      {
         InstantiateNext();
      } else if (done)
      {
         CheckWinAndNotInstantiate();
      }

      return done;
   }

   #endregion

   #region On Mouse Up Functions

   public void SetPositionBasedOnVector3(Transform t)
   {
      //current_section = go_on ? PlazaSections.part1 : PlazaSections.init
      float x_index = 0f;

      if (t.position.x < line_vert_1_x_position)
      {
         ResetALL();
         //t.position = new Vector3(x_default_position, t.position.y, 0f);
         //TODO instantiate next here?

      }
      else if (t.position.x >= line_vert_1_x_position && t.position.x < line_vert_2_x_position)
      {
         if (!SetPositionPrivateFunction(0))
         {
            ResetALL();
            t.position = new Vector3(x_default_position, Rnd.Range(-0.8f, 2.6f), 0f);
         }
      }
      else if (t.position.x >= line_vert_2_x_position && t.position.x < line_vert_3_x_position)
      {
         if (!SetPositionPrivateFunction(1))
         {
            ResetALL();
            t.position = new Vector3(x_default_position, Rnd.Range(-0.8f, 2.6f), 0f);
         }
      }
      else if (t.position.x >= line_vert_3_x_position)
      {
         if (!SetPositionPrivateFunction(2))
         {
            ResetALL();
            t.position = new Vector3(x_default_position, Rnd.Range(-0.8f, 2.6f), 0f);
         }
      }


   }

   private void ResetALL()
   {
      ResetIndexes(current_element_drag_script.x_grid_index_current,
         current_element_drag_script.y_grid_index_current);
      current_element_drag_script.x_grid_index_current = -2;
      current_element_drag_script.y_grid_index_current = -2;
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
      current_element_sprite_renderer = t.gameObject.GetComponent<SpriteRenderer>();

   }

   /// <summary>
   /// Private, use this to reset xy matrix indexes
   /// </summary>
   /// <param name="x_index"></param>
   /// <param name="y_index"></param>
   private bool ResetIndexes(int x_index, int y_index)
   {
      if (x_index == -2 && y_index == -2)
      {
         return false;
         
      } else if (!(x_index == -1 && y_index == -1))
      {
         xy[x_index, y_index] = false;
         return false;
      }
      else
      {
         return true;
      }
   }

   #endregion

   #region Instantiate Functions


   /// <summary>
   /// Private, use this to instantiate a new box with random colour
   /// </summary>
   private void IntantiateBox()
   {
      GameObject go = Instantiate(
         level_selector.GetCurrentLevelElement(indexes_sequence_of_elements_to_instantiate[index]).interacting_element,
         new Vector3(x_default_position, y_default_position, 0f),
         Quaternion.identity);
      current_element_drag_script = go.GetComponent<DragElement>();
      current_element_transform = go.transform;
      current_element_sprite_renderer = go.GetComponent<SpriteRenderer>();
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
      else
      {
         CheckWinAndStartCoroutine();
      }
   }

   private void CheckWinAndNotInstantiate()
   {
      if (index >= indexes_sequence_of_elements_to_instantiate.Count)
      {
         CheckWinAndStartCoroutine();
      }

   }

   #endregion

   #region Win

   private void CheckWinAndStartCoroutine()
   {
      bool win = true;
      for (int i = 0; i < Grid_Dimension; i++)
      {
         for (int j = 0; j < Grid_Dimension; j++)
         {
            if (!title_sprites[i].Equals(xy_sprites[i, j]))
            {
               win = false;
               break;
            }
         }
      }

      if (win)
      {
         StartCoroutine(CheckWin());
      }
   }

   IEnumerator CheckWin()
   {
      yield return new WaitForSeconds(1f);
      LoadWinUI();
      
   }

   #endregion

   #region Menu


   public void LoadLevelSelection()
   {
      game_canvas.SetActive(false);
      level_canvas.SetActive(true);
      win_element.SetActive(false);
      hand_mouse.SetActive(false);
   }

   public void DestroyAll()
   {
      GameObject[] title_boxes = GameObject.FindGameObjectsWithTag("box_title");
      foreach (var go in title_boxes)
      {
         Destroy(go);
      }
      
      title_sprites = new Sprite[Grid_Dimension];
      GameObject[] interactable_boxes = GameObject.FindGameObjectsWithTag("box");
      foreach (var go in interactable_boxes)
      {
         Destroy(go);
      }

      xy = new bool[Grid_Dimension,Grid_Dimension];
      xy_sprites = new Sprite[Grid_Dimension, Grid_Dimension];
      index = 0;

   }

   public void LoadLeveLUI()
   {
      game_canvas.SetActive(true);
      level_canvas.SetActive(false);
      win_element.SetActive(false);
      hand_mouse.SetActive(true);  
   }

   public void LoadWinUI()
   {
      win_element.SetActive(true);
   }

   public void ReloadLevel()
   {
      win_element.SetActive(false);
      GameObject[] interactable_boxes = GameObject.FindGameObjectsWithTag("box");
      foreach (var go in interactable_boxes)
      {
         Destroy(go);
      }

      xy = new bool[Grid_Dimension,Grid_Dimension];
      xy_sprites = new Sprite[Grid_Dimension, Grid_Dimension];
      // setup the index of the indexes_sequence_of_elements_to_instantiate at 0
      index = 0;

      // instantiate the first interactable box
      IntantiateBox();
   }

   #endregion

   public void LoadHomeMenu()
   {
      SceneManager.LoadSceneAsync("HomeScene");
   }
   
}
