using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {

        //byt scene med knapp tryck 1 eller 2
        if (Input.GetKey("1"))
        {
            SceneManager.LoadScene("scene");
        }

        else if (Input.GetKey("2"))
        {
            SceneManager.LoadScene("scene2");
        }

    }
}
