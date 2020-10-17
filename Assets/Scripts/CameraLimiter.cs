using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimiter : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(targetToFollow.position.x, 315f, 587f), 
        Mathf.Clamp(targetToFollow.position.y, 137f, 324f),transform.position.z);

         
    }
}
