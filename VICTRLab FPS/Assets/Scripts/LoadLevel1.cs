using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour {
    public string scene;
	void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            SceneManager.LoadScene(scene);
        }
    }
}
