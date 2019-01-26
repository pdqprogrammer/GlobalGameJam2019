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

    public GameObject[] furniBullets;
    public GameObject[] paintBullets;
    public GameObject[] floorBullets;
    public GameObject[] demoBullets;

    public int currentWeapon = 0;//0 - furni, 1 - paint, 2 - floors, 3 - demo
    public int currentAmmo = 0;

    public float furniWeaponCoolDownTime = 1.0f;

    private float furniCurrentCoolDownTime = 0.0f;
    private bool furniWeaponFired = false;

    private int ammoTypes = 1;

    private void Start()
    {
        ammoTypes = furniBullets.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //get current position and rotation of gun
        Vector3 gunPos = transform.position;
        Quaternion gunRot = transform.rotation;

        //check for player input of fire
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !furniWeaponFired)
        {
            //based on weapon instantiate correct bullet
            if (currentWeapon == 0)
            {
                Instantiate(furniBullets[currentAmmo], gunPos, gunRot);
            }
            else if (currentWeapon == 1)
            {
                Instantiate(paintBullets[currentAmmo], gunPos, gunRot);
            }
            else if (currentWeapon == 2)
            {
                Instantiate(floorBullets[currentAmmo], gunPos, gunRot);
            }
            else if (currentWeapon == 3)
            {
                Instantiate(demoBullets[currentAmmo], gunPos, gunRot);
            }

            furniWeaponFired = true;
        }

        //check if weapon has been fired
        if (furniWeaponFired)
        {
            furniCurrentCoolDownTime += Time.deltaTime;//increment time until next fire

            //if time is greater than cool down time reset weapon for fire
            if (furniCurrentCoolDownTime >= furniWeaponCoolDownTime)
            {
                ResetFurniWeapon();
            }
        }

        //check for player input of fire
        if (Input.GetButtonDown("Fire2"))
        {
            //swap between weapons
            ResetFurniWeapon();

            currentWeapon++;

            if (currentWeapon > 3)
                currentWeapon = 0;

            currentAmmo = 0;

            if (currentWeapon == 0)
            {
                ammoTypes = furniBullets.Length;
            }
            else if (currentWeapon == 1)
            {
                ammoTypes = paintBullets.Length;
            }
            else if (currentWeapon == 2)
            {
                ammoTypes = floorBullets.Length;
            }
            else if (currentWeapon == 3)
            {
                ammoTypes = demoBullets.Length;
            }
        }

        if (Input.GetKeyUp("left shift"))
        {
            currentAmmo++;

            if (currentAmmo >= ammoTypes)
                currentAmmo = 0;
        }
    }

    private void ResetFurniWeapon()
    {
        furniWeaponFired = false;
        furniCurrentCoolDownTime = 0.0f;
    }
}
