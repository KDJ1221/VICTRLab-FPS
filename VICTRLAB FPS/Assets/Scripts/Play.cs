using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    public void PlayAsCop() {
        SceneManager.LoadScene("Virtual Shop");
        PersistentManagerScript.Instance.isCop = true;
    }

    public void PlayAsRobber() {
        SceneManager.LoadScene("Virtual Shop");
        PersistentManagerScript.Instance.isCop = false;
    } 
}
