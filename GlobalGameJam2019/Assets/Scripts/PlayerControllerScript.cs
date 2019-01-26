using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float playerSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check for input
        if(Input.GetAxis("Horizontal") != 0)
        {

        }

        if(Input.GetAxis("Vertical") != 0)
        {

        }
    }
}
