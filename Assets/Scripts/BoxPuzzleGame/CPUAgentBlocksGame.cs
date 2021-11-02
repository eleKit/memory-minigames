using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUAgentBlocksGame : MonoBehaviour
{
    private BoxGameManager box_game_manager;
    public BoxDataManager box_data_manager;

    //private Queue<BoxGameManager.BoxElement> moved_left_items;
    // Start is called before the first frame update
    void Start()
    {
        //moved_left_items = new Queue<BoxGameManager.BoxElement>();
        box_game_manager = GameObject.FindGameObjectWithTag("boxManager").GetComponent<BoxGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteSuccessAction()
    {
        bool available = box_game_manager.CheckIndexesFree();
        bool success = true;

        if (available)
        {
            
            Debug.Log("success try");
            success = box_game_manager.SetPositionOfAgentElement(
                box_game_manager.current_element_drag_script.x_correct_index);
        } else
        {
            TryFromWrongOrLeftmost();
        }

        if (!success)
        {
            TryFromWrongOrLeftmost();
        }
    }

    private void TryFromWrongOrLeftmost()
    {
        if (!SetCurrentElementAndMoveLeftMost())
        {
            Debug.Log("here");
            PickFromLeftmostList();
        }
    }

    public void ExecuteRandMaybe()
    {
        if (box_game_manager.GetIfAllItemsAreOnScreen())
        {
            ExecuteSuccessAction();
        }
        else
        {
            ExecuteRandomAction();
        }
    }

    public void ExecuteRandomAction()
    {
        int tmp_x_index = Random.Range(0, box_game_manager.title_sprites.Length);
        bool done = false;
        for (int i = 0; i < box_game_manager.GetGridElements() ; i++)
        {
            if (box_game_manager.CheckIfASpecificIndexIsFree(tmp_x_index))
            {
                done = true;
                break;
            }
            tmp_x_index = Random.Range(0, box_game_manager.GetGridDimension());
        }
        if (done)
        {
            box_game_manager.SetPositionOfAgentElement(tmp_x_index);
        }
        /*else
        {
            SetCurrentElementAndMoveLeftMost();
        }*/
    }

    private bool SetCurrentElementAndMoveLeftMost()
    {
        bool list_not_empty = box_data_manager.wrong_box_items.Keys.Count > 0;
        if (list_not_empty)
        {
            foreach (var key in box_data_manager.wrong_box_items.Keys)
            {
                box_game_manager.SetCurrentTransformAgent(box_data_manager.wrong_box_items[key]);
                break;
            }
            box_game_manager.SetMostLeftPositionOfAgentElement();
        }

        return list_not_empty;
    }

    private void PickFromLeftmostList()
    {
        if (box_data_manager.leftmost_items.Keys.Count > 0)
        {
            foreach (var key in box_data_manager.leftmost_items.Keys)
            {
                box_game_manager.SetCurrentTransformAgent(box_data_manager.leftmost_items[key]);
                break;
            }
        }
        box_game_manager.SetPositionOfAgentElement(
            box_game_manager.current_element_drag_script.x_correct_index);
    }
}
