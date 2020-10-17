using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapons : MonoBehaviour
{
    public GameObject SomTiro;
    [SerializeField] private Rigidbody rbShoot;
    private float shootspeed = 50;
    private float projectDestroyTime = 6;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            squadAttack();
        }
    }
    public void squadAttack()
    {
        Rigidbody instantiatedProjectile = Instantiate(rbShoot, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.forward * shootspeed;
        DestroyShoot(instantiatedProjectile);
        AtivarSFXTiro();
        Invoke("DesativarSFXTiro", 0.5f);
    }
    public void DestroyShoot(Rigidbody project)
    {
        Destroy(project.gameObject, projectDestroyTime);
    }
    public void AtivarSFXTiro()
    {
        SomTiro.SetActive(true);
    }
    public void DesativarSFXTiro()
    {
        SomTiro.SetActive(false);
    }
}
