using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Congratulations : MonoBehaviour {

    public Text congrats;
	void Start () {
		if (PersistentManagerScript.Instance.isCop) {
            congrats.text = "Congratulations! \nYou escaped Nearstrom and have detained the robbers!";
        }
        else {
            congrats.text = "Congratulations! \nYou have escaped from the police!";
        }
	}
	
}
