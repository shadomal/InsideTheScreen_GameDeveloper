
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

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true) //novo
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            BackPlayer();
            AtivarSfxTroca();
            Invoke("DesativarSfxTroca", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {

            ativarChicote();
            Invoke("desativarChicote", 1.1f);
        }
    }
}
