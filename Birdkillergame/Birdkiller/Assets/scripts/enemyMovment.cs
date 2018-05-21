using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyMovment : MonoBehaviour
{


    public float speed = 3f;
    Transform target;

    void Start()
    {

    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("player").transform; //hitta spelare
        //rotera mot spelare
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);


        //rör mot spelare
        if (Vector3.Distance(transform.position, target.position) > 0f)
        {//rör dig mot spelare ifall distansen är mera än 0
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }
    //krock kontroll
    private void OnTriggerEnter2D(Collider2D col)

    {
        //ifall spelare gör skada
        if (col.gameObject.CompareTag("player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
            Destroy(this.gameObject);

        }

    }

}