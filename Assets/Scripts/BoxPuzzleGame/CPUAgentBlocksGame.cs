using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUAgentBlocksGame : MonoBehaviour
{
    private BoxGameManager box_game_manager;

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
        for (int i = 0; i < box_game_manager.title_sprites.Length; i++)
        {
            if (box_game_manager.title_sprites[i].Equals(box_game_manager.current_element_sprite_renderer.sprite))
            {
                box_game_manager.SetPositionOfAgentElement(i);
                break;
            }
        }
    }

    public void ExecuteRandomAction()
    {
        box_game_manager.SetPositionOfAgentElement(Random.Range(0,box_game_manager.title_sprites.Length));
    }

    public void FixWrongAction()
    {
        //BoxElement element = box_game_manager.wrong_items.Dequeue();
        //box_game_manager.SetMostLeftPositionOfAgentElement(element.GetTransform());

    }
}
