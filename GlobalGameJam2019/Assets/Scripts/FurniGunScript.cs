using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

//require objects to ensure runs properly
[RequireComponent(typeof (GameObject))]

public class FurniGunScript : MonoBehaviour
{
    public GameObject currentFurniBullet;
    public GameObject currentDecoBullet;

    public float furniWeaponCoolDownTime = 1.0f;

    private float furniCurrentCoolDownTime = 0.0f;
    private bool furniWeaponFired = false;

    public float decoWeaponCoolDownTime = 1.0f;

    private float decoCurrentCoolDownTime = 0.0f;
    private bool decoWeaponFired = false;

    // Update is called once per frame
    void Update()
    {
        //check for player input of fire
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !furniWeaponFired)
        {
            //spawn current furniture bullet
            Vector3 gunPos = this.transform.position;
            Quaternion gunRot = this.transform.rotation;

            GameObject furniObj = Instantiate(currentFurniBullet, gunPos, gunRot);
        }

        //check if weapon has been fired
        if (furniWeaponFired)
        {
            furniCurrentCoolDownTime += Time.deltaTime;//increment time until next fire

            //if time is greater than cool down time reset weapon for fire
            if(furniCurrentCoolDownTime >= furniWeaponCoolDownTime)
            {
                furniWeaponFired = false;
                furniCurrentCoolDownTime = 0.0f;
            }
        }

        //check for player input of fire
        if (CrossPlatformInputManager.GetButtonDown("Fire2") && !decoWeaponFired)
        {
            //spawn current furniture bullet
            Vector3 gunPos = transform.position;

            Quaternion rootRotation = transform.root.rotation;
            Quaternion parentRotation = transform.parent.rotation;

            Quaternion gunRot = transform.rotation;
            //Quaternion gunRot = transform.root.rotation;

            GameObject bulletObj = Instantiate(currentDecoBullet, gunPos, gunRot);
        }

        //check if weapon has been fired
        if (decoWeaponFired)
        {
            decoCurrentCoolDownTime += Time.deltaTime;//increment time until next fire

            //if time is greater than cool down time reset weapon for fire
            if (decoCurrentCoolDownTime >= decoWeaponCoolDownTime)
            {
                decoWeaponFired = false;
                decoCurrentCoolDownTime = 0.0f;
            }
        }
    }
}
