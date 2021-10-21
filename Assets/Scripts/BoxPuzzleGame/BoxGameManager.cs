using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;
using Rnd = UnityEngine.Random;
using Image = UnityEngine.UI.Image;

public class BoxGameManager : MonoBehaviour
{
   
   public GameObject Player1;
   public GameObject Player2;
   public GameObject switchPlayerButton;

   private Image player1Image;
   private Image player2Image;

   private Color hilightColor = new Color(0, 1, 1);
   
   private SaveNumPlayers save_num_players;
   
   private const int Grid_Dimension = 3;

   private const int Elements_in_Grid = 9;

   private const int number_of_arrays_of_levels = 5;

   /*public GameObject[] colour_title_elements;
   
   
   public GameObject[] colour_level_elements;
*/
   private List<int> indexes_sequence_of_elements_to_instantiate;


   public LevelSelector level_selector;

   public float y_title_position;
   public float[] y_positions;

   [Header("coordinates of sections to locate the box")]
   public float[] x_positions;

   [Header("conditions used to select the section to locate the box ")]
   public float line_vert_1_x_position;
   public float line_vert_2_x_position;
   public float line_vert_3_x_position;
   public float line_vert_overflow_x_position;

   private bool[,] xy = new bool[Grid_Dimension, Grid_Dimension];
   //private BoxElement[,] xy_sprites = new BoxElement[Grid_Dimension, Grid_Dimension];

   public Sprite[] title_sprites {get; private set;}

   public float x_default_position;
   public float y_default_position;

   public Transform current_element_transform { get; private set; } //value used by hand mouse indicator
   public SpriteRenderer current_element_sprite_renderer { get; private set; }
   private DragElement current_element_drag_script;

   public GameObject hand_mouse;

   //index used to instantiate the moving boxes in a level
   private int index = 0;

   public bool current_turn_is_player;
   
   private bool cpuIsOn;
   private bool multiplayer;

   [Header("game canvas")] public GameObject game_canvas;
   [Header("win canvas")] public GameObject win_element;
   [Header("levels canvas")] public GameObject level_canvas;

   public BoxDataManager box_data_manager;
   
   
   private void Start()
   {
      title_sprites = new Sprite[Grid_Dimension];
      //wrong_items = new Queue<BoxElement>();
      indexes_sequence_of_elements_to_instantiate = new List<int>();
      save_num_players = GameObject.FindGameObjectWithTag("save_number_players").GetComponent<SaveNumPlayers>();
      player1Image = Player1.GetComponent<Image>();
      player2Image = Player2.GetComponent<Image>();
      switch (save_num_players.GetPlayOption())
      {
         case SaveNumPlayers.PlayOptions.agent:
            cpuIsOn = true;
            Player1.SetActive(true);
            Player2.SetActive(true);
            switchPlayerButton.SetActive(true);
            break;
         case SaveNumPlayers.PlayOptions.couple:
            multiplayer = true;
            Player1.SetActive(true);
            Player2.SetActive(true);
            switchPlayerButton.SetActive(true);
            break;
         default:
            Player1.SetActive(true);
            Player2.SetActive(false);
            switchPlayerButton.SetActive(false);
            break;
      }

      box_data_manager.SetupDataManager();
      ResetColors();
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
      int random = Rnd.Range(0, number_of_arrays_of_levels + 1);
      level_selector.GenerateRandomSingleLevel(random);
      SetupLevel();
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
      if (current_turn_is_player)
      {
         SetPositionPrivateFunction(x_index);
      }
   }

   public void ChangeCPUTurn()
   {
      current_turn_is_player = !current_turn_is_player;
      ResetColors();
      if (current_turn_is_player)
         player1Image.color = hilightColor;
      else 
         player2Image.color = hilightColor;
   }
   
   void ResetColors()
   {
      player1Image.color = Color.white;
      player2Image.color = Color.white;
   }
   
   
   #endregion
   
   #region AgentFunctions
   
   
   public void SetPositionOfAgentElement(int x_index)
   {
      if (!current_turn_is_player)
      {
         SetPositionPrivateFunction(x_index);
      }
   }

   public void SetMostLeftPositionOfAgentElement(Transform t)
   {
      if (!current_turn_is_player)
      {
         SetLeftMostPosition(t);
      }
   }
   
   private void SetLeftMostPosition(Transform t)
   {
      ResetALL();
      t.position = new Vector3(Rnd.Range(line_vert_1_x_position - 2, line_vert_1_x_position), 
         Rnd.Range(0.3f, 2.4f), 0f);
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
      else if (t.position.x >= line_vert_3_x_position && t.position.x < line_vert_overflow_x_position)
      {
         if (!SetPositionPrivateFunction(2))
         {
            ResetALL();
            t.position = new Vector3(x_default_position, Rnd.Range(-0.8f, 2.6f), 0f);
         }
      } else if (t.position.x >= line_vert_overflow_x_position)
      {
         ResetALL();
         t.position = new Vector3(x_default_position, t.position.y, 0f);
      }


   }

   #endregion

   #region Common Functions

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
            current_element_transform.position = new Vector3(x_positions[x_index], y_positions[y_index], 0f);
            current_element_drag_script.x_grid_index_current = x_index;
            current_element_drag_script.y_grid_index_current = y_index;
            break;
         }
      }

      // here the agent has access to know if the move is wrong
      /* infatti la lista di sbagliati si è incrementata di 1 e la CPU ha accesso alla lista */
      if (current_element_drag_script.x_correct_index != x_index)
      {
         box_data_manager.box_items[current_element_drag_script.instantiation_index].win = false;
         if (!box_data_manager.wrong_box_items.ContainsKey(current_element_drag_script.instantiation_index))
         {
            box_data_manager.wrong_box_items.Add(current_element_drag_script.instantiation_index,
               box_data_manager.box_items[current_element_drag_script.instantiation_index]);
         }
      }
      else
      {
         box_data_manager.box_items[current_element_drag_script.instantiation_index].win = true;
         if (box_data_manager.wrong_box_items.ContainsKey(current_element_drag_script.instantiation_index))
         {
            box_data_manager.wrong_box_items.Remove(current_element_drag_script.instantiation_index);
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
   
   
   private void ResetALL()
   {
      ResetIndexes(current_element_drag_script.x_grid_index_current,
         current_element_drag_script.y_grid_index_current);
      if (!(current_element_drag_script.x_grid_index_current == -1 &&
            current_element_drag_script.y_grid_index_current == -1))
      {
         current_element_drag_script.x_grid_index_current = -2;
         current_element_drag_script.y_grid_index_current = -2;
      }
   }


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
      for (int i = 0; i < Grid_Dimension; i++)
      {
         if (title_sprites[i].Equals(current_element_sprite_renderer.sprite))
         {
            current_element_drag_script.x_correct_index = i;
            break;
         }
      }

      current_element_drag_script.instantiation_index = index;
      
      box_data_manager.box_items.Add(index, 
         new BoxElement(current_element_transform, current_element_drag_script, current_element_sprite_renderer));

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

   #endregion

   #region Win

   
   private void CheckWinAndNotInstantiate()
   {
      if (index >= indexes_sequence_of_elements_to_instantiate.Count)
      {
         CheckWinAndStartCoroutine();
      }

   }
   
   private void CheckWinAndStartCoroutine()
   {
      bool win = true;

      if (box_data_manager.box_items.Keys.Count == (Grid_Dimension * Grid_Dimension))
      {
         foreach (var key in box_data_manager.box_items.Keys)
         {
            if (!box_data_manager.box_items[key].win)
            {
               Debug.Log("false index: " + key);
               win = false;
               break;
            }
         }
      }
      
      Debug.Log("full size: " + box_data_manager.box_items.Keys.Count + " ; wrong size: " + box_data_manager.wrong_box_items.Keys.Count);

      if (win)
      {
         Debug.Log("win");
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

   private void SetupLevel()
   {
      LoadLeveLUI();
      DestroyAll();
       
      box_data_manager.ResetDataManager();
       
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
      current_turn_is_player = true;
      player1Image.color = hilightColor;
   }

   private void DestroyAll()
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
      //xy_sprites = new BoxElement[Grid_Dimension, Grid_Dimension];
      index = 0;

   }
   
   public void ReloadLevel()
   {
      win_element.SetActive(false);
      StopAllCoroutines();
      box_data_manager.ResetDataManager();
      GameObject[] interactable_boxes = GameObject.FindGameObjectsWithTag("box");
      foreach (var go in interactable_boxes)
      {
         Destroy(go);
      }

      xy = new bool[Grid_Dimension,Grid_Dimension];
      // xy_sprites = new BoxElement[Grid_Dimension, Grid_Dimension];
      // setup the index of the indexes_sequence_of_elements_to_instantiate at 0
      index = 0;

      // instantiate the first interactable box
      IntantiateBox();
   }
   
   #endregion

   #region MenuUI

   public void LoadLevelSelection()
   {
      DestroyAll();
      StopAllCoroutines();
      game_canvas.SetActive(false);
      level_canvas.SetActive(true);
      win_element.SetActive(false);
      hand_mouse.SetActive(false);
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
   

   public void LoadHomeMenu()
   {
      SceneManager.LoadSceneAsync("HomeScene");
   }
   
   
   #endregion
   
}
