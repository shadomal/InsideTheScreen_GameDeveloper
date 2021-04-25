using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player_core : MonoBehaviour
{
    //array de players;
    [SerializeField] private GameObject[] players = new GameObject[2];
    private Rigidbody rigidPlayer;
    public float jumpForce = 300;
    private int life;
    private int speed;
    private int MaxLife;
    [SerializeField] private Image _lifeBar;
    public bool onGround = true;                    //novo
    public GameObject Chicote;                    // novo
    public GameObject SomTrocaDePers;
    public GameObject TelaVitoria;
    public GameObject SomAmbiente;
    public GameObject SomVitoria;
    public GameObject SomLevandoDano;

    private Animator anim;
    [SerializeField] private GameObject CanvasDeath;
    private void Awake()
    {
        life = 100;
        speed = 20;
        MaxLife = 100;
        rigidPlayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }
    //movimentação e pulo;
    public void move(float moveH, float moveV)
    {
        Vector3 novaVel = Vector3.right * moveH * speed;
        if (moveH < 0 && transform.rotation.eulerAngles.y != 270)
        {
            Vector3 newRot = new Vector3(0, 270, 0);
            transform.rotation = Quaternion.Euler(newRot);
        }
        if (moveH > 0 && transform.rotation.eulerAngles.y != 90)
        {
            Vector3 newRot = new Vector3(0, 90, 0);
            transform.rotation = Quaternion.Euler(newRot);
        }
        //transform.Rotate(0, moveH * speed, 0);
        novaVel.y = rigidPlayer.velocity.y;
        rigidPlayer.velocity = novaVel;
        if (moveH > 0 || moveH < 0)
        {
            anim.SetBool("andar", true);
        }
        else
        {
            anim.SetBool("andar", false);
        }
    }
    public void jump()
    {
        //rigidPlayer.velocity = new Vector3(0, jumpForce, 0);
        rigidPlayer.AddForce(0, jumpForce, 0);
        onGround = false; //novo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("pular", false);
        }
        else
        {
            anim.SetBool("pular", true);
        }
    }

    //Colisores e triggeres
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyShoot")
        {
            applyDamage(15);
        }
        if (other.gameObject.tag == "life")
        {
            IncrementHealth(100);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "limbo")
        {
            applyDamage(500);
        }

        if (other.gameObject.tag == "doorPuzzle")
        {
            applyDamage(20);
        }
        if (other.gameObject.tag == "chao")         //novo
        {
            onGround = true;                        //novo
        }
        if (other.gameObject.tag == "moeda")         //novo
        {
            TelaVitoria.SetActive(true);             //novo
            SomAmbiente.SetActive(false);
            SomVitoria.SetActive(true);
        }

    }

    //Ataques

    public void ativarChicote()                     //novo
    {
        Debug.Log("chicote ativado");
        Chicote.SetActive(true);
    }

    public void desativarChicote()                  //novo
    {
        Debug.Log("chicote desativado");
        Chicote.SetActive(false);
    }

    //TROCA DE PERSONAGEM
    public void SwitchControl()
    {
        if (players[0] != null)
        {
            players[0].gameObject.GetComponent<Player_Control>().enabled = false;
        }
        Debug.Log("Troquei");
        if (players[1] != null)
        {
            players[1].gameObject.GetComponent<PlayerTwoControl>().enabled = true;
        }
    }
    public void BackPlayer()
    {
        if (players[0] != null)
        {
            players[0].gameObject.GetComponent<Player_Control>().enabled = true;
        }
        Debug.Log("Troquei");
        if (players[1] != null)
        {
            players[1].gameObject.GetComponent<PlayerTwoControl>().enabled = false;
        }

    }



    public void AtivarSfxTroca()
    {
        SomTrocaDePers.SetActive(true);
    }
    public void DesativarSfxTroca()
    {
        SomTrocaDePers.SetActive(false);
    }

    public void DeathController()
    {
        Destroy(gameObject);
        CallDeathScene();
        /*if (isDead())
        {
            Debug.Log("On death Scene Calling");
            CallDeathScene();
        }*/
    }

    public bool isDead()
    {
        return players[0] == null && players[1] == null;
    }

    public void CallDeathScene()
    {
        //Cena de morte dos player
        CanvasDeath.gameObject.SetActive(true);
    }

    //Controladores de vida
    public void applyDamage(int damageTake)
    {
        SetHealth(this.life - damageTake);
        AtivarSomDano();
        Invoke("DesativarSomDano", 0.5f);

    }
    public int getHealth() => this.life;

    public void SetHealth(int _life)
    {
        if (_life > MaxLife)
        {
            this.life = MaxLife;
        }
        else
        {
            this.life = _life;
        }

        UpdateLifeBar();

        if (this.life <= 0)
        {
            if (players[0] == gameObject)
            {
                players.SetValue(null, 0);
            }
            else if (players[1] == gameObject)
            {
                players.SetValue(null, 1);
            }
            DeathController();
        }
    }

    public void IncrementHealth(int lifeIncrement) => this.SetHealth(this.life + lifeIncrement);

    public void UpdateLifeBar()
    {
        this._lifeBar.fillAmount = ((1.0f / this.MaxLife) * this.life);
    }

    public void AtivarSomDano()
    {
        SomLevandoDano.SetActive(true);
    }
    public void DesativarSomDano()
    {
        SomLevandoDano.SetActive(false);
    }
}

