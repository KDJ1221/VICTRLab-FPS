using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpill : MonoBehaviour {

    public Vector3 spillRate;
    public Vector3 spillFinish;
	// Update is called once per frame
	void Update () {
        if(transform.localScale != spillFinish) {
            transform.localScale += spillRate;
        }
	}
}
