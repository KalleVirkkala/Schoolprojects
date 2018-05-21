using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{

    // Use this for initialization



    private void OnCollisionEnter2D(Collision2D col)
    {

        //krock kontroll = ge spelare mera liv 
        if (col.gameObject.CompareTag("player"))
        {


            col.gameObject.GetComponent<PlayerHealth>().AddHealth();

            Destroy(this.gameObject);


        }
    }
}

