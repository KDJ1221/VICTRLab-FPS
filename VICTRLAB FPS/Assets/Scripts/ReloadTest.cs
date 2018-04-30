using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadTest : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            SceneManager.LoadScene("testFPS");
        }
    }
}
