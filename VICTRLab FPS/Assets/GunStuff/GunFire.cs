using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.Play();
            GetComponent<Animation>().Play("GunShot");
        }
	}
}
