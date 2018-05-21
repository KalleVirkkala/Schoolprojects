using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    Rigidbody2D rb;
    public float maxSpeed = 10f;
    bool facingRight = true;
    Animator anim;
    public float jumpPower = 150f;


    public LayerMask groundLayer;
    // Use this for initialization
    void Start()
    {
        //hämta komponeneter
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

  
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        //gå till höger på piltangent höger
        if (Input.GetKey("right"))
        {
            //sått animation att spleare går
            anim.SetBool("isWalking", true);
            moveRight();
        }
        //gå till vänster på piltangent vänster
        else if (Input.GetKey("left"))
        {
            anim.SetBool("isWalking", true);
            moveLeft();
        }
        //sått animation till idle ifall inte spelaren rör sig
        else
        {
            anim.SetBool("isWalking", false);
        }
        //hoppa på pil uppåt
        if (Input.GetKey("up"))
        {

            jump();
        }


        //vänd spelare mot färd riktning
        if (move > 0 && !facingRight)
        {
            Flip();
        }

        else if (move < 0 && facingRight)
        {
            Flip();
        }



    }
    //hoppa
    void jump()
    {

        if (!IsGrounded())
        {
            return;
        }
        else
        {
            rb.AddForce(Vector2.up * jumpPower);
        }
    }




    void moveLeft()
    {

        rb.velocity = new Vector2(-Input.GetAxis("Horizontal") * -maxSpeed, rb.velocity.y);
    }

    void moveRight()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }


    // är på marken kontroll
    bool IsGrounded()
    {

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        Debug.DrawRay(position, direction, Color.green);
        //"skjut" en stråle och kontrolera ifall den träffar marken
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }


        return false;
    }
}
