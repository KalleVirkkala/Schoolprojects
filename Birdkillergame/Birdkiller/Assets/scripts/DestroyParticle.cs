using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {
    //förstör partikeleffekt efter 1 sekund
    void Awake()
    {
 Destroy(this.gameObject,1);
 }

}
