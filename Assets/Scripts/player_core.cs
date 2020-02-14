using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_core : MonoBehaviour
{
    private int health;
    private int maxHealth;
    private int speed;
    private float jumpBoost;
    private string displayName;
    private Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        maxHealth = 35;
        jumpBoost = 0;
        displayName = null;
        speed = 10;
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

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

    //movimentação personagem.
    public void move(Vector3 vector3)
    {
        if (vector3.x > 1)
        {
            rg.velocity = new Vector3(vector3.x + speed, vector3.y, vector3.z);
        }
        else if (vector3.y > 1)
        {
            jump();
        }
        else if (vector3.z > 1){
            rg.velocity = new Vector3(vector3.x, vector3.y, vector3.z + speed);
        }

    }
    //Colisores.
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
    //Metodos.
    public void jump(float jump)
    {
        rg.AddForce(new Vector3(0, 0, 5 + jumpBoost));
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
            Debug.Log("Death");
        }
        else
        {
            Debug.Log("Live" + health);
        }
    }
}

