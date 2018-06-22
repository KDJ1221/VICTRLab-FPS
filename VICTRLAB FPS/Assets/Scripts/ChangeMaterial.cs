using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    public Material[] material;
    Renderer rend;
    bool shirt;

    // Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        shirt = PersistentManagerScript.Instance.isCop;
	}
	
	// Update is called once per frame
	void Update () {
        if(shirt) {
            rend.sharedMaterial = material[0];
        }
        else {
            rend.sharedMaterial = material[1];
        }
	}
}
