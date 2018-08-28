using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour {
    public string sceneName;
	void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            SceneManager.LoadScene(sceneName);
        }
    }
}
