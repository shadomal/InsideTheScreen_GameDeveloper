using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : player_core
{
    //Script com função de ir dentro do player executando somente sua função.

   
    void Start()
    {

    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Click");
            move(new Vector3(0, 0, +1));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move(new Vector3(0, 0, -1));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move(new Vector3(+1, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            jump(1);
        }
    }
}
