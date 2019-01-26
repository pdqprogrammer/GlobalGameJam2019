using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required components for bullet object
[RequireComponent(typeof(Rigidbody))]

public class FlooringBulletScript : MonoBehaviour
{
    //public variables to be set in editor
    public float bulletSpeed = 1.0f;//use this for fine tuning separate bullets
    public Material flooringMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //setup bullet color
        gameObject.GetComponent<Renderer>().material = flooringMaterial;

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

        if (collision.gameObject.tag.Equals("Floors"))
        {
            collision.gameObject.GetComponent<Renderer>().material = flooringMaterial;
        }

        Destroy(gameObject);
    }
}