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
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        move(moveH, moveV);

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true) //novo
        {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SwitchControl();
            AtivarSfxTroca();
            Invoke("DesativarSfxTroca", 1.0f);
            //Controlador de Troca de Personagem
        }
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            IncrementHealth(10);
        }
    }


}