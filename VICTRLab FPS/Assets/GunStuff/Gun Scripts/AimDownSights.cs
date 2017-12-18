using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSights : MonoBehaviour {

    public Vector3 aimDownSight;
    public Vector3 hipFire;
    public float aimspeed = 0;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1)) {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSight, aimspeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(1)) {
            transform.localPosition = hipFire;
        }
	}
}
