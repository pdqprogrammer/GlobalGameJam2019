using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required components for bullet object
[RequireComponent (typeof(Rigidbody))]

public class BulletScript : MonoBehaviour
{
    public enum BulletType
    {
        Furniture, Paint, Flooring, Lighting
    };

    //public variables to be set in editor
    public float bulletSpeed = 1.0f;//use this for fine tuning separate bullets
    public BulletType bulletType = BulletType.Furniture;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        //apply force to object when it is created
        if (bulletType == BulletType.Furniture)
        {
            rb.AddForce(transform.forward * bulletSpeed * 10);
        }
        else if (bulletType != BulletType.Furniture)
        {
            rb.AddForce(transform.forward * bulletSpeed * 1000);
        }
    }

    private void FixedUpdate()
    {
    }

    //add collision code here for non furniture game object destroys
    private void OnCollisionEnter(Collision collision)
    {
        if (bulletType == BulletType.Paint)
        {
            if (collision.gameObject.tag.Equals("Walls") || collision.gameObject.tag.Equals("Ceiling") || collision.gameObject.tag.Equals("Furniture"))
            {
                collision.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
            }
        }

        if (bulletType != BulletType.Furniture)
        {
            Destroy(gameObject);
        }
    }
}
