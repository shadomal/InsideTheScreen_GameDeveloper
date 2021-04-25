using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallInterface : InterfaceCore
{
    [SerializeField] private GameObject levelClear;
    public GameObject derrota;
    public GameObject player;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player1" || other.gameObject.tag == "player2")
        {
            levelClear.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void deathplayer()
    {
        if (player = null)
        {
            derrota.SetActive(true);
        }
    }
}
