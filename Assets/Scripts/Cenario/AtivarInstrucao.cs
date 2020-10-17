using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarInstrucao : MonoBehaviour
{
    public GameObject CavaloMeio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision colision)
    {
       if (colision.gameObject.tag == "player1" || colision.gameObject.tag == "player2")
        {
            CavaloMeio.SetActive(true);
        }
    }
}
