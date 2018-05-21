using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public GameObject death;
    int health = 10; //liv  
    public AudioSource source;
    Animator anim;


    void Awake()
    {

        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    //ta skada funktion
    public void Damage(int damage)

    {
        health -= damage;

        //ifall inget liv kvar dö
        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            //spela ljud klipp för död
            source.Play();

            //gör en instans av partikeleffekt
            Instantiate(death, transform.position, transform.rotation);
            //förstör komponeneter och spelobjekt
            Destroy(this.gameObject.GetComponent<enemyMovment>());
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
            Destroy(this.gameObject.GetComponent<PolygonCollider2D>());
            Destroy(this.gameObject, 3);

        }
    }
}


