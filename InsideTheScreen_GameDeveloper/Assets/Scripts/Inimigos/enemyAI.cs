using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private GameObject[] players = new GameObject[1];
    private int targetID;
    private void Awake()
    {
        this.targetID = 0;
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void findPlayer()
    {
        //NavMash Config;
        if (players[1] == null)
        {
            targetID = 1;
            enemyAgent.SetDestination(players[0].transform.position);
            return;
        }
        if (players[0] == null)
        {
            targetID = 1;
            enemyAgent.SetDestination(players[1].transform.position);
            return;
        }
        if (Vector3.Distance(transform.position, players[0].transform.position) <
       Vector3.Distance(transform.position, players[1].transform.position))
        {
            targetID = 0;
            enemyAgent.SetDestination(players[0].transform.position);
        }
        else
        {
            targetID = 1;
            enemyAgent.SetDestination(players[1].transform.position);
        }
    }

    public GameObject GetTarget()
    {
        if (players[targetID] == true)
        {
            return players[targetID];
        }
        return null;
    }
    

}
