using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Desativar : MonoBehaviour
{
    public bool isImgOn;
    public GameObject img;
    
 
     void Start () {

        Invoke("ativarCavalo", 3.0f);
     }
  void OnCollisionEnter(Collision collision)
 {
     if (isImgOn == true) {
 
                 img.SetActive(false);
                 isImgOn = false;
             }
 }

    void ativarCavalo()
    {
        img.SetActive(true);
        isImgOn = true;
    }

}
 

