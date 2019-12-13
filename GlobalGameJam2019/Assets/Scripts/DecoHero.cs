using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class DecoHero : MonoBehaviour
{
    public enum GameState
    {
        Title,
        Intro,
        InGame,
        Success
    };

    public GameState gameState = GameState.Title;

    private GameObject titleUI;
    private GameObject introUI;
    private GameObject inGameUI;
    private GameObject successUI;

    private float freezeInputTimer = 0.0f;
    public float maxFreezeInputTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        titleUI = GameObject.Find("Title");
        introUI = GameObject.Find("Instructions");
        inGameUI = GameObject.Find("InGame");
        successUI = GameObject.Find("Success");

        titleUI.SetActive(false);
        introUI.SetActive(false);
        inGameUI.SetActive(false);
        successUI.SetActive(false);

        if(gameState == GameState.Title)
        {
            titleUI.SetActive(true);
        }
        else if (gameState == GameState.InGame)
        {
            StartGame();
        } 
        else if (gameState == GameState.Intro)
        {
            introUI.SetActive(true);
        }
        else if (gameState == GameState.Success)
        {
            successUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //poll for input and perform certain actions based on state
        if(gameState != GameState.InGame)
        {
            if(gameState == GameState.Title)
            {
                //check for any button after input freeze lifted to transition to next scene
                if(CrossPlatformInputManager.GetButtonDown("Fire1") && freezeInputTimer >= maxFreezeInputTime)
                {
                    freezeInputTimer = 0.0f;
                    gameState = GameState.Intro;
                    titleUI.SetActive(false);
                    introUI.SetActive(true);
                }
            }
            else if(gameState == GameState.Intro)
            {
                //check for any button after input freeze lifted to transition to next scene
                if (CrossPlatformInputManager.GetButtonDown("Fire1") && freezeInputTimer >= maxFreezeInputTime)
                {
                    freezeInputTimer = 0.0f;
                    gameState = GameState.InGame;
                    introUI.SetActive(false);
                    StartGame();
                }
            }
            else if(gameState == GameState.Success)
            {
                //build out to eventually reset game state to a default state here
                //reset level
                if (CrossPlatformInputManager.GetButtonDown("Fire1") && freezeInputTimer >= maxFreezeInputTime)
                {
                    ResetGame();
                }
            }

            if (freezeInputTimer < maxFreezeInputTime)
            {
                freezeInputTimer += Time.deltaTime;
            }
        }
        else
        {
            //check for specific input to complete game
            if(Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
            {
                gameState = GameState.Success;
                EndGame();
                successUI.SetActive(true);
            }

            if (Input.GetKeyDown("l"))
            {
                //build out to eventually reset game state to a default state
                //reset game on press
                //ResetGame();
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void ResetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void StartGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        FirstPersonController fpsController = player.GetComponent<FirstPersonController>();

        if (!fpsController.enabled)
        {
            fpsController.enabled = true;
        }

        GameObject playerWeapon = GameObject.Find("BulletSpawnPoint");
        FurniGunScript furniGunScript = playerWeapon.GetComponent<FurniGunScript>();

        if (!furniGunScript.enabled)
        {
            furniGunScript.enabled = true;
        }

        inGameUI.SetActive(true);
    }

    private void EndGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        FirstPersonController fpsController = player.GetComponent<FirstPersonController>();

        if (fpsController.enabled)
        {
            fpsController.enabled = false;
        }

        GameObject playerWeapon = GameObject.Find("BulletSpawnPoint");
        FurniGunScript furniGunScript = playerWeapon.GetComponent<FurniGunScript>();

        if (furniGunScript.enabled)
        {
            furniGunScript.enabled = false;
        }

        inGameUI.SetActive(false);
    }
}
