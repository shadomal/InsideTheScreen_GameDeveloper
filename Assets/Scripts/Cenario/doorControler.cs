using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControler : PuzzleEvents
{

    [SerializeField]
    private Animator _animDoor;
    // Update is called once per frame
    private float forceDoorOpen;
    private GameObject _door;
    private void Awake() {
        forceDoorOpen = 5;
        _animDoor = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player1")
        {
            _door = _doors[0];
            _animDoor.SetTrigger("Porta Subindo");
        }
        
        /*if (other.gameObject.tag == "player2" || other.gameObject.tag == "playerWhip")
        {
            _door = _doors[1];
            _animDoor.Play("porta subir");
        }
        
        if (other.gameObject.tag == "player1")
        {
            _door = _doors[2];
            _animDoor.Play("porta subir");
        }*/
    }

}
