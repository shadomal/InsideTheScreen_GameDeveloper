using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPlayer : MonoBehaviour
{
    public GameObject[] players = new GameObject[1];
    // Start is called before the first frame update
    public bool Cswitch;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            PlayerSwitch();
        }
    }
    public void PlayerSwitch()
    {
        if (Cswitch == true)
        {
            players[0].GetComponent<Player_Control>().enabled = false;
            players[1].GetComponent<Player_Control>().enabled = true;
        }
        else
        {
            players[0].GetComponent<Player_Control>().enabled = true;
            players[1].GetComponent<Player_Control>().enabled = false;
        } 
    }
}
