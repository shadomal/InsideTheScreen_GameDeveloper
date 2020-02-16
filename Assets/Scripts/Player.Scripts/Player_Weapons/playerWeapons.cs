using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapons : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject playerWithWhip;
    [SerializeField] private float shootspeed;
    [SerializeField] private long playerShootSpeed;
    [SerializeField] private float projectDestroyTime;
    [SerializeField] private float whipTimeDestroy;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        playerShootSpeed = 2000;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        shootspeed = 20;
        projectDestroyTime = 3;
        whipTimeDestroy = 5;
    }
    public void playerShoot()
    {
        Rigidbody instantiatedProjectile = Instantiate(rb, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.forward * shootspeed;
        DestroyObj(instantiatedProjectile);
    }

    public void FireON()
    {

        if (isInCooldown())
        {
            return;
        }
        SetCooldown(playerShootSpeed);
        playerShoot();
    }
    public long GetTimeNow() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    private long cooldown = 0L;
    public void SetCooldown(long millis)
    {
        this.cooldown = GetTimeNow() + millis;
    }
    public bool isInCooldown() => GetTimeNow() < this.cooldown;






    public void DestroyObj(Rigidbody project)
    {// vou deitar e ver algo ja colo ;v
        Destroy(project.gameObject, projectDestroyTime);
    }
    public void playAnimWhip()
    {
        anim.Play("atkChicote");
    }


    //eu fiquei pensando quando tava escrevendo pedrin... meio que assim se a gente vai ativar algo que já está dentro do player, eu fiz lá
    //no outro código no caso player.core que ativa isso com essa função aqui
    // public void whipConfig(){
    //players[2].transform.GetChild(2).gameObject.SetActive(true);
    //whipAtack();
    //}
    //Só que tipo eu fiquei parando e analizando, como isso vai ficar dentro do jogo em si.... a gente vai pegar e fica instanciando o chichote,
    //ou podemos colocar e tipo criar um script único pro chicote que nem você tinha feito e colocar ele instanciado para cá no caso playerWeapons.
    //dai jogamos fica nessa hierarquia chicoteControler => playerWeapons => player.core => player_Control;
    //oque tá me bugando são os 2 players, tipo os 2 tão com player control tlg dai fiquei confuso se isso afetaria... n sei agora.. amanha se der a gente vê na parte da noite;
}
