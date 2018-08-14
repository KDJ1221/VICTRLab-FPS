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
        SceneManager.LoadScene("Virtual Shop");
        PersistentManagerScript.Instance.isCop = false;
    }

    public void PlayAsRobber() {
        SceneManager.LoadScene("Virtual Shop");
        PersistentManagerScript.Instance.isCop = true;
    } 
}
