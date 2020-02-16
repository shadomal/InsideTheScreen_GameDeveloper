using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPointControler : MonoBehaviour
{
    [SerializeField]
    private Transform checkPoint;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            player.transform.position = checkPoint.position;
            player.transform.rotation = checkPoint.rotation;
        }
    }
}
