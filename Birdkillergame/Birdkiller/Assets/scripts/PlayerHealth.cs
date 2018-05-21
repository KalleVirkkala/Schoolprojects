using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;                            //spelar liv
    public int currentHealth;                                   //spelar nuvarande liv
    public Slider HealthSlide;                                
    public Image damageImage;                                   // bild på canvas som blinkar när man tar skada.                   
    public float flashSpeed = 5f;                               // hur snabbt transparenten går på bilden
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // bildens färg
    PlayerMove Movement;                                        // referens till spelar rörelse
    shootArrow Shooting;                                        //referens till spelar skjutande
    bool isDead;                                                // är spelaren död?
    bool damaged;                                               // har spelaren tagit skada
    public GameObject death;                        
    public AudioClip dmgClip;                                   //audioklip för skada
    AudioSource playerAudio;
    void Awake()
    {



        // sätter fullt liv åt spelaren
        currentHealth = startingHealth;
        playerAudio = GetComponent<AudioSource>();
        Movement = GetComponent<PlayerMove>();
        Shooting = GetComponentInChildren<shootArrow>();
    }


    void Update()
    {
        // ifall spelaren har tagit skada
        if (damaged)
        {
            // lägg färgen av bilden 
            damageImage.color = flashColour;
        }
       
        else
        {
            //från röd tillbaka till transparent
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        
        damaged = false;



    }

    //ta skada funktion
    public void TakeDamage(int amount)
    {

       
        // har tagit skada boolean

        damaged = true;
        //spela ljudklip
         playerAudio.Play();
        // reducera liv med skada
        currentHealth -= amount;

        // minska på slidern
        HealthSlide.value = currentHealth;


        // om inget liv klar = död
        if (currentHealth <= 0 && !isDead)
        {
         
            Death();
        }
    }

    public void AddHealth()

    {
        currentHealth += 20;

    }
    void Death()
    {
        // kontroll att är död
        isDead = true;

        // stäng av skript på spelare,förstör spelobjekt och starta om scenen
        Movement.enabled = false;
        Shooting.enabled = false;
       
        Destroy(this.gameObject, 4);
        int index = Random.Range(0, 1);
        Debug.Log(index);

            SceneManager.LoadScene("scene");



      
        


    }
}