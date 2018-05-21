using UnityEngine;
using System.Collections;

public class CameraFollow: MonoBehaviour
{

    public GameObject player;


    private Vector3 offset;         
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Use this for initialization
    void Start()
    {
        //kalkylera offset mella camera och spelare
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        // sätt samma position till camera och spelare men offset
        transform.position = player.transform.position + offset;
        //camera kan ändast röra sig på storleken av spelplanet
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),

                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));


        }


    }
}