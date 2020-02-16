using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoControl : player_core
{
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        move(moveH, moveV);

        if (Input.GetKey(KeyCode.Space))
        {
            jump(1);
        }

        //Controles de ataque do player

        if (Input.GetKey(KeyCode.J))
        {


        }
        if (Input.GetKey(KeyCode.K))
        {
            //whipAtack();
        }
        if (Input.GetKey(KeyCode.H))
        {
            switchControl();  //Controlador de Troca de Personagem
        }

        verifySwitch();
    }
}
