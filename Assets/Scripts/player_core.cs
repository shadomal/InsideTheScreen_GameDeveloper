using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_core : MonoBehaviour
{
    private int health;
    private int maxHealth;
    private int speed;
    private float jumpBoost;
    private string displayName;
    private Rigidbody rgPlayer;
    private Animator animPlayer;
    //Caso precise
    private Camera cam;

    //Awake = O script estará ativado independendo de está sendo usado ou não.
    private void Awake()
    {
        health = 10;
        maxHealth = 35;
        jumpBoost = 0;
        displayName = null;
        speed = 50;
        rgPlayer = GetComponent<Rigidbody>();
        animPlayer = GetComponent<Animator>();
    }

    void Start()
    {

    }


    void Update()
    {
        //Função para identificar aproximação do mouse em objetos dentro da cena;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 15))
        {
            if (hit.collider.tag == "tag escolhida")
            {
                //ação que ocorre ao passar o mouse em cima de algo
            }
        }
    }
    //gets e sets para os atributos privados.
    public string getName()
    {
        return displayName;
    }
    public void setName(string name)
    {
        this.displayName = name;
    }

    //Metódo de movimentação do personagem.
    public void move(Vector3 vector3)
    {                              //ESPAÇO PARA COMENTARIOS
        Debug.Log("Função ON!!!!");// 
                                   //
                                   // 
                                   // 
                                   //  

        if (vector3.x >= 1)
        {
            rgPlayer.velocity = new Vector3(+speed, 0, 0);
        }
        else if (vector3.x <= 1)
        {
            rgPlayer.velocity = new Vector3(-speed, 0, 0);
        }

        if (vector3.z >= 1)
        {
            rgPlayer.velocity = new Vector3(0, 0, +speed);
        }
        else if (vector3.z <= 1)
        {
            rgPlayer.velocity = new Vector3(0, 0, -speed);
        }
    }

    //Colisores e suas respectivas funções.
    private void OnCollisionEnter(Collision OtherObj)
    {
        if (OtherObj.gameObject.tag == "enemy")
        {
            applyDamage(5);
        }
    }
    private void OnCollisionExit(Collision exitObj)
    {

    }

    //Metódos.
    public void jump(float jump)
    {
        rgPlayer.AddForce(new Vector3(0, 5 + jumpBoost, 0));
    }

    public void jump()
    {
        jump(0.0f);
    }

    public void applyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
        else
        {
            Debug.Log("Live" + health);
        }
    }
    //ESPAÇO PARA COMENTARIOS
    //
    //
    // 
    //

    //Metódo para respawn e morte do player evitando que ele dependa exclusivamente que seu hp chegue a zero para dizer que ele morreu...
    public void die()
    {
        //Aba destaca para troca de Cena para "Cena de Morte com botão de respawn"
        SceneManager.LoadScene("Tela Morte");

    }

    public void respawn()
    {

    }
}

