using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unload : MonoBehaviour {

    public GameObject loadingScreen;

	void Start () {
        StartCoroutine(TurnOffLoadingScreen());
	}
	
	IEnumerator TurnOffLoadingScreen() {
        yield return new WaitForSeconds(1f);
        loadingScreen.SetActive(false);
	}
}
