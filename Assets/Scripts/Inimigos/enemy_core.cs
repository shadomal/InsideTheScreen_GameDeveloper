using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class enemy_core : MonoBehaviour
{
    [SerializeField] private GameObject[] players = new GameObject[1];
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private GameObject[] enemies = new GameObject[1];
    [SerializeField] private Transform[] TransformPlayer = new Transform[2];
    [SerializeField] private int enemyHealth;

    //Controladores de ataque
    [SerializeField] private GameObject enemyShootPrefb;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float shootspeed;
    [SerializeField] private float projectDestroyTime;
    [SerializeField] private long timeShoot;
    [SerializeField] private Image healthBar_;

    private int targetID;


    // Start is called before the first frame update

    private void Awake()
    {
        this.targetID = 0;
        //enemies = GameObject.FindGameObjectsWithTag("Player");
        enemyHealth = 100;
        //Atribuindo variaveis de ataque;
        shootspeed = 50;
        projectDestroyTime = 10;
        timeShoot = 1200;
        enemyAgent = this.GetComponent<NavMeshAgent>();
    }
    //metodos acessores gets e sets

    //Metodos
    public void findPlayer()
    {
        if (players[targetID] == true)
        {
            enemyAgent.SetDestination(TransformPlayer[targetID].position);
            return;
        }

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == true)
            {
                targetID = i;
                enemyAgent.SetDestination(TransformPlayer[i].position);
                break;
            }
        }
    }

    public GameObject GetTarget()
    {
        if (players[targetID] == true)
        {
            return players[targetID];
        }
        return null;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player1")
        {
           SetEnemyHealth(0);
        }
        if (other.gameObject.tag == "limbo")
        {
            EnemyDie();
        }
        if (other.gameObject.tag == "projectile")
        {
            SetEnemyHealth(15);
        }
    }
    private void OnTriggerEnter(Collider playersObj)
    {
        if (playersObj.gameObject.tag == "projectile")
        {
            SetEnemyHealth(-15);
        }
    }

    private void OnTriggerStay(Collider chicote)
    {
        if (chicote.gameObject.tag == "playerWhip")
        {
            SetEnemyHealth(1);
        }
    }


    //Tratamento para vida do inimigo;
    public int getHealth() => this.enemyHealth;
    public void setHealth(int Health)
    {
        enemyHealth -= Health;
        if (enemyHealth <= 0)
        {
            enemyDeath();
        }

    }

    public void enemyDeath()
    {
        Destroy(gameObject);
    }
    //Controlador de Ataque inimigo;
    public void enemyShoot()
    {
        Rigidbody instantiatedProjectile = Instantiate(rb, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.forward * shootspeed;
        DestroyShoot(instantiatedProjectile);
    }
    public void DestroyShoot(Rigidbody project)
    {// vou deitar e ver algo ja colo ;v
        Destroy(project.gameObject, projectDestroyTime);
    }

    public void FireON()
    {
        if (GetTarget() != null)
        {
            if (isInCooldown())
            {
                return;
            }
            SetCooldown(timeShoot);
            enemyShoot();
        }
    }
    public long GetTimeNow() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    private long cooldown = 0L;
    public void SetCooldown(long millis)
    {
        this.cooldown = GetTimeNow() + millis;
    }

    public bool isInCooldown() => GetTimeNow() < this.cooldown;

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
    public int GetEnemyHealth() => this.enemyHealth;
    public void SetEnemyHealth(int health)
    {
        enemyHealth -= health;
        DrainHealthBar();
        if (this.enemyHealth <= 0)
        {
            EnemyDie();
        }
    }
    public void DrainHealthBar()
    {
        this.healthBar_.fillAmount -= 0.100f; //1 <-
        if(healthBar_.fillAmount <= 0){
            Destroy(gameObject);
        }
    }
}
 