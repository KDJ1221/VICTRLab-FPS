using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {

    public float lifeTime;

	// Use this for initialization
	void Start () {
		
	}

    void OnEnable() {
        Invoke("SetAct", lifeTime);
    }

    void SetAct() {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        transform.localEulerAngles = new Vector3(0, Random.Range(0, 359), 0);
		
	}
}
