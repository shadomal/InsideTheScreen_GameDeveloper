using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_core : playerWeapons
{
    [SerializeField] private GameObject[] players = new GameObject[1];
    private int health;
    private int maxHealth;
    private int speed;
    private float jumpBoost;
    private string displayName;
    private Rigidbody rgPlayer;
    private Animator animPlayer;
    private Transform trans;
    private bool playerSwitch2;
    //Caso precise
    private Camera cam;
    //Controlador Troca de Jogador
    private bool playerSwitch;
    //Awake = O script estará ativado independente de está sendo usado ou não.
    private long cooldown = 0L;
    private Animator anim;

    private int countPlayer;

    private void Awake()
    {
        countPlayer = 0;
        health = 10;
        maxHealth = 35;
        jumpBoost = 0;
        displayName = null;
        speed = 10;
        rgPlayer = GetComponent<Rigidbody>();
        animPlayer = GetComponent<Animator>();
        anim = GetComponent<Animator>();
        playerSwitch = false;
    }
    void Start()
    {
        //players[1].gameObject.GetComponent<Player_Control>().enabled = false;
    }

    void Update()
    {

        // Função para identificar aproximação do mouse em objetos dentro da cena;
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
    public void move(float moveH, float moveV)
    {                              //ESPAÇO PARA COMENTARIOS
                                   //
                                   //
                                   // Arrumar a movimentação em Y e X para o objeto/player cair suavimente.
                                   // 
                                   //  
                                   //rgPlayer.velocity = new Vector3(moveH * speed, rgPlayer.velocity.y, moveV * speed);
        rgPlayer.velocity = transform.forward * moveV * speed;
        transform.Rotate(0, moveH * speed, 0);
    }

    //Colisores e suas respectivas funções.
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "enemyShoot")
        {
            applyDamage(1);
        }
    }
    public void OnCollisionExit(Collision exitObj)
    {

    }
    private void OnTriggerEnter(Collider otherTriggrs)
    {
        if (otherTriggrs.gameObject.tag == "enemyShoot")
        {
            applyDamage(1);
        }
    }
    public void OnCollisionStay(Collision OtherObj)
    {
        if (OtherObj.gameObject.tag == "HealthBonus")
        {
            changeHealth(10);
        }
        else if (OtherObj.gameObject.tag == "Limbo")
        {
            Limbo();
        }

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
        drainHealth(1);
    }

    public void playAnimation()
    {
        // run animatio

    }

    private GameObject getActiveControl()
    {
        return players[countPlayer];
    }

    private long getTimeNow()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public void verifySwitch()
    {
        /*Debug.Log("Jogador atual: " + countPlayer + " | Status: " + (players[countPlayer] == false));
        if (players[countPlayer] == false)
        {
            
        }*/
    }

    /*public void switchControl()
    {
        if (getTimeNow() < cooldown)
        {
            playerSwitch = false;
            return;
        }   
        cooldown = getTimeNow() + 5000;
        Debug.Log("Tempo Restante = " + cooldown * 1000);
        playerSwitch = true;
        Debug.Log("Desativando jogador: " + countPlayer);
        players[0].gameObject.GetComponent<Player_Control>().enabled = false;
        players[0].transform.GetChild(0).gameObject.SetActive(false);

        //countPlayer = getNextAllowed();

        if (playerSwitch == true)
        {
            playerSwitch2 = true;
            playerSwitch = false;
            Debug.Log("Ativando jogador: " + countPlayer);
            players[1].gameObject.GetComponent<PlayerTwoControl>().enabled = true;
            players[1].transform.GetChild(0).gameObject.SetActive(true);
            players[1].transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (playerSwitch2 == true)
        {
            playerSwitch = true;
            playerSwitch2 = false;
            players[0].gameObject.GetComponent<Player_Control>().enabled = true;
            players[0].transform.GetChild(0).gameObject.SetActive(true);
            
        }
        //if //else
    }*/
    // private long getTimeNow()
    // {
    //     return System.DateTime.Now.Millisecond;
    // }
    // private long delay = 0L;

    private bool canExecute = false;


    public void switchControl()
    {
        if (getTimeNow() < cooldown)
        {
            playerSwitch = false;
            return;
        }
        cooldown = getTimeNow() + 5000;
        // Debug.Log(delay + " | " + getTimeNow());
        // if (delay >= getTimeNow())
        // {
        //     Debug.Log("Code stopped");
        //     return;
        // }
        // delay = getTimeNow() + 825;
        players[countPlayer].gameObject.GetComponent<Player_Control>().enabled = false;
        players[countPlayer].transform.GetChild(0).gameObject.SetActive(false);

        countPlayer = (countPlayer + 1 >= players.Length ? 0 : countPlayer + 1);
        //if //else
        players[countPlayer].gameObject.GetComponent<Player_Control>().enabled = true;
        players[countPlayer].transform.GetChild(0).gameObject.SetActive(true);
    }

    public int getNextAllowed()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[countPlayer] == true)
            {
                return countPlayer;
            }
        }
        return -1;
    }

    //ESPAÇO PARA COMENTARIOS
    //
    //
    // 
    //

    //Metódo para respawn e morte do player evitando que ele dependa exclusivamente que seu hp chegue a zero para dizer que ele morreu...
    public void die()
    {
        Destroy(gameObject);
    }
    public void Limbo()
    {
        setHealth(-500);
    }
    public void respawn()
    {

    }
    // public void whipAtack()
    // {
    //     Debug.Log("Function On!!! enable animation;");
    //     players[1].transform.GetChild(1).gameObject.SetActive(true);
    //     playAnimWhip();

    // }

    // Everthing about health
    public int getHealth() => this.health;

    public void setHealth(int health)
    {
        if (health >= maxHealth)
        {
            this.health = maxHealth;
        }
        else if (health <= 0)
        {
            this.die();
        }
        else
        {
            this.health = health;
        }
    }
    public void changeHealth(int incrementHealth) => this.setHealth(this.health + incrementHealth);
    public void drainHealth(int damage) => this.setHealth(this.health - damage);
}

