using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIScript : MonoBehaviour
{
    public Sprite[] toolSprites;

    public Sprite[] paintAmmoSprites;
    public Sprite[] furniAmmoSprites;
    public Sprite[] floorAmmoSprites;
    public Sprite[] demoAmmoSprite;

    GameObject furniGunObject;
    FurniGunScript furniGunScript;

    private int currWeapon = 0;
    private int currAmmo = 0;

    // Start is called before the first frame update
    void Start()
    {
        furniGunObject = GameObject.Find("BulletSpawnPoint");
        furniGunScript = furniGunObject.GetComponent<FurniGunScript>();

        int[] initialWeaponSettings = furniGunScript.GetWeaponSettings();

        currWeapon = initialWeaponSettings[0];
        currAmmo = initialWeaponSettings[1];

        //set sprites in UI
        SetWeaponSprites();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int[] currWeaponSettings = furniGunScript.GetWeaponSettings();

        if(currWeapon != currWeaponSettings[0] || currAmmo != currWeaponSettings[1])
        {
            currWeapon = currWeaponSettings[0];
            currAmmo = currWeaponSettings[1];

            //set sprites in UI
            SetWeaponSprites();
        }
    }

    private void SetWeaponSprites()
    {
        GameObject toolUI = GameObject.Find("ToolImage");
        GameObject ammoUI = GameObject.Find("AmmoImage");

        Image toolUISprite = toolUI.GetComponent<Image>();
        Image ammoUISprite = ammoUI.GetComponent<Image>();

        //set to current tool
        toolUISprite.sprite = toolSprites[currWeapon];

        if(currWeapon == 0)
        {
            ammoUISprite.sprite = furniAmmoSprites[currAmmo];
        }
        else if(currWeapon == 1)
        {
            ammoUISprite.sprite = paintAmmoSprites[currAmmo];
        }
        else if (currWeapon == 2)
        {
            ammoUISprite.sprite = floorAmmoSprites[currAmmo];
        }
        else if (currWeapon == 3)
        {
            ammoUISprite.sprite = demoAmmoSprite[0];
        }
    }
}
