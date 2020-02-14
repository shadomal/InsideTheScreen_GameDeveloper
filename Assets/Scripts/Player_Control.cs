using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : player_core
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Click");
            move(new Vector3(+1, 0, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move(new Vector3());
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move(new Vector3());
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            jump(1);
        }
    }
}
