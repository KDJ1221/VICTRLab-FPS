using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Congratulations : MonoBehaviour {

    public Text congrats;
	void Start () {
		if (!PersistentManagerScript.Instance.isCop) {
            congrats.text = "Congratulations! \nYou escaped Nearstrom and successfully defeated the gang members!";
        }
        else {
            congrats.text = "Congratulations! \nYou escaped Nearstrom and successfully defeated the police officers!";
        }
	}
	
}
