using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required components for bullet object
[RequireComponent(typeof(Rigidbody))]

public class PaintBulletScript : MonoBehaviour
{
    //public variables to be set in editor
    public float bulletSpeed = 1.0f;//use this for fine tuning separate bullets
    public Color paintColor;

    // Start is called before the first frame update
    void Start()
    {
        //setup bullet color
        paintColor.a = 1.0f;
        gameObject.GetComponent<Renderer>().material.color = paintColor;

        Rigidbody rb = GetComponent<Rigidbody>();
        //apply force to object when it is created
        rb.AddForce(transform.forward * bulletSpeed * 1000);
    }

    //add collision code here for non furniture game object destroys
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag.Equals("FloorContainer") || collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("FurniContainer"))
        {
            Collider thisCollider = GetComponent<Collider>();

            Physics.IgnoreCollision(collision.collider, thisCollider);
            return;
        }

        if (collision.gameObject.tag.Equals("Walls") || collision.gameObject.tag.Equals("Ceiling") || collision.gameObject.tag.Equals("Furniture"))
        {
            Debug.Log("paint happened");
            collision.gameObject.GetComponent<Renderer>().material.color = paintColor;
        }

        Destroy(gameObject);
    }
}