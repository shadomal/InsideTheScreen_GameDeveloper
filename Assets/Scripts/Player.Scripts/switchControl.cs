using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchControl : MonoBehaviour
{


    //Script responsavel exclusivamente para a troca de jogadores dentro de game;
    //Para utilizar basta coloca-lo dentro de um jogador e a função será ativada;
    //Atalho de tecla = H;

    private GameObject[] players = new GameObject[2];
    private int countPlayer;
    [SerializeField] private GameObject _canvas;
    void Awake()
    {

    }
    void Update()
    {

    }

    public void cooldownSwitch()
    {

    }
    public void playerSwitchControl()
    {
        players[0].transform.GetComponent<Player_Control>().enabled = false;
        players[1].transform.GetComponent<PlayerTwoControl>().enabled = true;
    }
    public void switchTwo()
    {
        players[0].transform.GetComponent<Player_Control>().enabled = true;
        players[1].transform.GetComponent<PlayerTwoControl>().enabled = false;
    }

    public void DeathController()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != gameObject)
            {
                players[i].transform.GetChild(0).gameObject.SetActive(false);
                players[i].transform.GetComponent<Player_Control>().enabled = true;
                if (players[i] == null)
                {
                    CallDeathScene();
                }
            }
        }
    }
    public void CallDeathScene()
    {
        _canvas.gameObject.SetActive(true);
    }

}
