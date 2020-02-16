using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youwin : MonoBehaviour
{
    [SerializeField] private GameObject CanvasWin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "players")
        {
            CanvasWin.SetActive(true);
            pauseFunction();
        }
    }
    private void pauseFunction()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
}
