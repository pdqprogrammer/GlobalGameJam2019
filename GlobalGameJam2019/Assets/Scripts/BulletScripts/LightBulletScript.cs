using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required components for bullet object
[RequireComponent(typeof(Rigidbody))]

public class LightBulletScript : MonoBehaviour
{
    //public variables to be set in editor
    public float bulletSpeed = 1.0f;//use this for fine tuning separate bullets

    public GameObject ceilingLight;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        //apply force to object when it is created
        rb.AddForce(transform.forward * bulletSpeed * 1000);
    }

    //add collision code here for non furniture game object destroys
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag.Equals("FloorContainer") || collision.gameObject.tag.Equals("Player"))
        {
            return;
        }

        if (collision.gameObject.tag.Equals("Ceiling"))
        {
            //setup ceiling light
            Instantiate(ceilingLight, gameObject.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}