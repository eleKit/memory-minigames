using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheCurrentBox : MonoBehaviour
{
    private BoxGameManager box_game_manager;

    private Transform me_trandform;

    private Vector3 offset = new Vector3(0.6f, -0.6f, 0f);
    
    // Start is called before the first frame update
    void Start()
    {
        me_trandform = this.GetComponent<Transform>();
        box_game_manager = GameObject.FindGameObjectWithTag("boxManager").GetComponent<BoxGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        me_trandform.position = box_game_manager.current_element_transform.position + offset;
    }
}
