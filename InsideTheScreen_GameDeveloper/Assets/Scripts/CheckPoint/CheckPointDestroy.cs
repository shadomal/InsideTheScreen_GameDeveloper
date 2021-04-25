using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDestroy : MonoBehaviour
{
    public GameObject checkPoint;

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Destroy(checkPoint);
            Destroy(gameObject);
        }
    }
}
