
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class rotateArrow : MonoBehaviour
{

    Animator anim;              
    public Vector2 fv;
    Rigidbody2D rb;
    bool hit = false;                           //träff kontroll
    public int arrowDamage = 10;                //pil skada 
    Collider2D other;                           
    GameObject player;                          
    PlayerHealth playerHealth;                

    void Start()
    {

       
        if (hit == false)
        {

            rb = GetComponent<Rigidbody2D>();

        }

    }

    void Update()
    {

        if (hit == false)
        {

            //pilen rör sig mot färd riktningen och roterar sig
            transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg) - 360);
        }




    }
    //pilen fastnar i objektet den träffar
    public void StickArrow()
    {

        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<PolygonCollider2D>());
        Destroy(this.gameObject, 8);


    }

    //krock check
    private void OnTriggerEnter2D(Collider2D other)


    {
        //träff!
        hit = true;

        //ifall träffat fienden 
        if (other.gameObject.CompareTag("Enemy"))
        {   

            //fiende liv script kontroll
            Enemyhealth script = other.gameObject.GetComponent<Enemyhealth>();

            if (script != null)
            {
                //gör skada
                script.Damage(arrowDamage);
                transform.parent = other.transform;

                
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<PolygonCollider2D>());
                Destroy(this.gameObject, 1);

            }

        }
        else
        {

            transform.parent = other.transform;
            StickArrow();
            //förstör pil efter 30 sekunder att den skjutits
            Destroy(this.gameObject, 30);
        }


    }



}


