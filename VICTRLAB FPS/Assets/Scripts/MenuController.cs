﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuController : MonoBehaviour {

    public string mainMenuScene;
    public string checkpointScene;
    public GameObject Player;
    public GameObject Gun; 
    public GameObject pauseMenu;
    public static bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = false;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
	}

    public void PauseGame() {
        if (isPaused) {
            isPaused = false;
            pauseMenu.SetActive(false);
            Player.GetComponent<FirstPersonController>().enabled = true;
            Gun.SetActive(true);
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
        else {
            isPaused = true;
            Player.GetComponent<FirstPersonController>().enabled = false;
            Gun.SetActive(false);
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

    public void ReturnToCheckpoint() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(checkpointScene);
    }

    public void ReturnToMain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame() {
        Application.Quit();
    }
}