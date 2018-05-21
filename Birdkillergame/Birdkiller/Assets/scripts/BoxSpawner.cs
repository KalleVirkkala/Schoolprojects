using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject box;
    public GameObject hbox;
    public float spawnTime = 1f;            // hur länge tid mellan att lådor "spawnar"
    public Transform[] spawnPoints;         //"spawn" array

 

    void Start()
    {
        //repetera "spawnar" 
        InvokeRepeating("Spawn", spawnTime, 10);
        InvokeRepeating("Spawn2", spawnTime, 20);
    }
    void Update()
    {
        spawnTime = 20f;
    }

    void Spawn()
    {
        //slumpmässig "spawn" plats
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
   

        //gör en intsans av låda
        Instantiate(box, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);


    }
    void Spawn2()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
 

        //gör en intsans av låda
        Instantiate(hbox, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);




    }

}