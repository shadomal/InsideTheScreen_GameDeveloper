using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYourself : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player1" || other.gameObject.tag == "player2")
        {
            Destroy(gameObject);
            Debug.Log("Vida obtida: 15" + " Auto Destruindo");
        }
    }
}
