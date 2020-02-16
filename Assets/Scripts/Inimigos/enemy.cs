using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : enemy_core
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireON();
        findPlayer();
    }
}
