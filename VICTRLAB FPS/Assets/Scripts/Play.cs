using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayAsCop() {
        PersistentManagerScript.Instance.isCop = false;
        PersistentManagerScript.Instance.loadScene = "Virtual Shop";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void PlayAsRobber() {
        PersistentManagerScript.Instance.isCop = true;
        PersistentManagerScript.Instance.loadScene = "Virtual Shop";
        SceneManager.LoadScene("LoadingScreen");
    } 
}
