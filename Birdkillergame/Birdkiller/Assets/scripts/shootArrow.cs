using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shootArrow : MonoBehaviour
{

    // Use this for initialization
    public GameObject prefab;
    public float speed;
    public float speed2 = 0f;
    public float maxSpeed = 20f;
    private bool powerInc = false;
    bool facingRight = true;
    public AudioSource shootsound; 
    // Use this for initialization
    Vector3 bowPos;
    Animator anim;
    public int ArrowAmmo;
    Text AmmoCount;



    void Start()
    {
        anim = GetComponent<Animator>();
        AmmoCount = GameObject.Find("AmmoCount").GetComponent<Text>();

    }
    //skjut pil
    void shoot()
    {

        //direction av mousen jämfört med spelare
        Vector3 shootDirection;
        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //gör en instans av pil
        GameObject projectile = Instantiate(prefab, bowPos, transform.rotation);
        //skjut mot musen
        shootDirection = new Vector2(shootDirection.x, shootDirection.y);
        shootsound.Play();
        //ge pilen en  hastighet
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * speed;
    }



    void Update()

    {
        //updatera pilmängd på UI
        string currentAmmo = ArrowAmmo.ToString();
        AmmoCount.text = currentAmmo;

        //kontrolera pilbågens position
        bowPos = transform.position;

        //dra båge med att hålla in mus knapp
        if (Input.GetMouseButtonDown(0) && ArrowAmmo > 0)
        {

            powerInc = true;
            anim.SetBool("isDrawn", true);


        }
        //släpp = skjut pil
        if (Input.GetMouseButtonUp(0) && ArrowAmmo > 0)
        {

            shoot();
            anim.SetBool("isDrawn", false);
            powerInc = false;
            speed2 = 0f;
            ArrowAmmo--;
        }

    }



    void FixedUpdate()
    {
        //kontrolera max hastighet på pilen
        float move = Input.GetAxis("Horizontal");
        //ge mera kraft till pilen
        if (powerInc)
        {
            if (speed2 < maxSpeed)
            {
                speed2 += Time.deltaTime * 15f;
                speed = speed2;
            }
            else
            {
                speed2 = maxSpeed;
                speed = speed2;



            }
            Debug.Log(speed2);
        }


        //vänd på pilbåge till färriktning av spelare
        if (move > 0 && !facingRight)
        {
            Flip();
        }

        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    //vänd
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    //lägg till pilar
    public void AddAmmo()
    {
        ArrowAmmo += 10;

    }
}