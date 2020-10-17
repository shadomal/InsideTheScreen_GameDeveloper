using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PuzzleEvents : MonoBehaviour
{
    // eventos publicos
    public GameObject[] _doors = new GameObject[5];
    //eventos privados
    [SerializeField]
    public static bool  _openDoor1, _openDoor2, _openDoor3, _openDoor4;
    [SerializeField]
    public GameObject somBotaoT;
    public GameObject somBotaoQ;

    private void Awake()
    {
        _openDoor1 = false;
        _openDoor2 = false;
        _openDoor3 = false;
        _openDoor4 = false;
         
    }
    private void Update()
    {

    }
    //trigger butão
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player encontrado" + gameObject.name);

        if (other.gameObject.tag == "player1")
        {
            _openDoor1 = true;
            this.OpenDoor();
            somBotaoQ.SetActive(true);
            
        }
        else if (other.gameObject.tag == "player2" || other.gameObject.tag == "playerWhip")
        {
            _openDoor2 = true;
            this.OpenDoor();
            somBotaoT.SetActive(true);
        }
    }
    public void OpenDoor()
    {
        if (_openDoor1 && _openDoor2)
        {
            Debug.Log("Função executada");
            this._doors[0].GetComponent<doorControler>().enabled = true;
            this._doors[0].GetComponent<Animator>().enabled = true;
            //this._doors[0].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void OpenDoorTwo(){
        if(_openDoor3){
            this._doors[1].GetComponent<doorControler>().enabled = true;
            this._doors[1].GetComponent<Animator>().enabled = true;
            this._doors[1].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void OpenDoorTree(){
        if(_openDoor4){
            this._doors[2].GetComponent<doorControler>().enabled = true;
            this._doors[2].GetComponent<Animator>().enabled = true;
            this._doors[2].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
