using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_core : MonoBehaviour
{
    private GameObject player;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //metodos acessores gets e sets
    public GameObject GetPlayer()
    {
        return player;
    }
    public void SetPlayer(GameObject playerInGame)
    {
        this.player = playerInGame;
    }

    //Metodos

    private void FindPlayer()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player");
    }



}
