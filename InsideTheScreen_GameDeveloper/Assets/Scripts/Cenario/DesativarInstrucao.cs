using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativarInstrucao : MonoBehaviour
{
    public GameObject CavaloMeio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision colision)
    {
        if (colision.gameObject.tag == "player1" || colision.gameObject.tag == "player2")
        {
            CavaloMeio.SetActive(false);
        }
    }
}
