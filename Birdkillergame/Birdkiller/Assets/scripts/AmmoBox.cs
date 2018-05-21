using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{


    public AudioSource yay;
    // Use this for initialization



        //krock kontroll för att spelaren har "plockat upp" lådan
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {

            yay.Play();
            //lägg till pilar i skjut skriptet på spelar pilbåge
            col.gameObject.GetComponentInChildren<shootArrow>().AddAmmo();
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject, 1f);


        }
    }
}
