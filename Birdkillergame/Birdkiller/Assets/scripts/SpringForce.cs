using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForce : MonoBehaviour {

    public float k;
    public float m;
    Rigidbody2D rb;
    public float Y1;
    public float gravity = -9.81f;
	// Use this for initialization
	void Start () {
        
        Y1 = transform.position.y;
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        
        float deltaY = transform.position.y - Y1;
        float Ag = gravity;
        float Af = (k * deltaY) / m;


        //weights acceleration
        float Ar = Ag - Af;
       Ar *= 0.10f;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + Ar);


		
	}
    private void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(0, Input.mousePosition.y);
        Vector2 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        pos.x = transform.position.x;
        transform.position = pos;

    }
}
