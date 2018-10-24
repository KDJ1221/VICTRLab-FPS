using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuController : MonoBehaviour {

    public string mainMenuScene;
    public string checkpointScene;
    public GameObject AmmoObject;
    public int StartingAmmo;
    public int ReserveAmmo;
    public GameObject Player;
    public GameObject Gun;
    public GameObject Enemy;
    public GameObject pauseMenu;
    public static bool isPaused;
    public int count;
    public int totalCount;

	// Use this for initialization
	void Start () {
        isPaused = false;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        StartingAmmo = AmmoObject.GetComponent<GlobalAmmo>().getLoadedAmmo();
        ReserveAmmo = AmmoObject.GetComponent<GlobalAmmo>().getCurrentAmmo();
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
        AmmoObject.GetComponent<GlobalAmmo>().resetAmmo(StartingAmmo, ReserveAmmo);
        Enemy.GetComponent<Target>().ResetCount(count);
        Enemy.GetComponent<Target>().ResetTotalCount(totalCount);
        SceneManager.LoadScene(checkpointScene);
    }

    public void ReturnToMain() {
        Time.timeScale = 1f;
        AmmoObject.GetComponent<GlobalAmmo>().resetAmmo(0, 0);
        Enemy.GetComponent<Target>().ResetCount(6);
        Enemy.GetComponent<Target>().ResetTotalCount(13);
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
