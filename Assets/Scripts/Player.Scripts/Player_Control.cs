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

        if (Input.GetKey(KeyCode.Space))
        {
            jump(1);
        }

        //Controles de ataque do player

        if (Input.GetKey(KeyCode.J))
        {
            FireON();
        }
        if (Input.GetKey(KeyCode.H))
        {
            switchControl();  //Controlador de Troca de Personagem
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
        
        verifySwitch();
    }


}
