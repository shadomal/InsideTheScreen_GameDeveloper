using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicote : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject playerWeapon;
    [SerializeField] public Animator animWhip;
    public float timeDisable;
    public long cooldown = 0L;
    float delay = 1.50f;
    public void Start()
    {
        animWhip = GetComponent<Animator>();
        timeDisable = 1.50f;
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("Ataque On!!!");
            AtaqueChicote();
            timeDisable -= 0.5f;
            Debug.Log(timeDisable);
        }
    }

    private long getTimeNow()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void function(){
        StartCoroutine(DisableWhip(delay));
    }
    public void AtaqueChicote()
    {

        playerWeapon.SetActive(true);
        animWhip.Play("atkChicote");
        playerWeapon.SetActive(false);
        function();
    }
    IEnumerator DisableWhip(float _delay){
        yield return new WaitForSeconds(_delay);
        this.playerWeapon.SetActive(false);
    }
}
