using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsPuzzleTwo : PuzzleEvents
{
    private void OnTriggerEnter(Collider doors) {
       if (doors.gameObject.tag == "player1")
        {
            _openDoor3 = true;
            this.OpenDoorTwo();
        }
        else if (doors.gameObject.tag == "player2" || doors.gameObject.tag == "playerWhip")
        {
            _openDoor4 = true;
            this.OpenDoorTree();
        }
   }
}
