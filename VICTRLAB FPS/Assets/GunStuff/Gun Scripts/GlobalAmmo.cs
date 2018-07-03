using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour {

    public static int CurrentAmmo;
    public int InternalAmmo;
    public GameObject AmmoDisplay;

    public static int LoadedAmmo = 20;
    public int InternalLoaded;
    public GameObject LoadedDisplay;
	
	// Update is called once per frame
	void Update () {
        InternalAmmo = CurrentAmmo;
        InternalLoaded = LoadedAmmo;
        AmmoDisplay.GetComponent<Text> ().text = "" + InternalAmmo;
        LoadedDisplay.GetComponent<Text>().text = "" + InternalLoaded;
	}
}
