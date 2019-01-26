using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required components for bullet object
[RequireComponent(typeof(Rigidbody))]

public class FurnitureBulletScript : MonoBehaviour
{
    //public variables to be set in editor
    public float bulletSpeed = 1.0f;//use this for fine tuning separate bullets

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        //apply force to object when it is created
        rb.AddForce(transform.forward * bulletSpeed * 10);    
    }
}
