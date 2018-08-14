using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSights : MonoBehaviour {

    public Vector3 aimDownSight;
    public Vector3 hipFire;
    public GameObject UpCurs;
    public GameObject DownCurs;
    public GameObject LeftCurs;
    public GameObject RightCurs;
    Vector3 deltaY = new Vector3(0, 10.0f, 0);
    Vector3 deltaX = new Vector3(10.0f, 0, 0);
    public bool isAiming = false;
    public float aimspeed = 0;

	// Not update anymore, changed so it can be a function call.
	public void Update () {

        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSight, aimspeed * Time.deltaTime);
            if (!isAiming) {
                isAiming = true;
                UpCurs.transform.position -= deltaY;
                DownCurs.transform.position += deltaY;
                LeftCurs.transform.position += deltaX;
                RightCurs.transform.position -= deltaX;
            }
        }
        
        else if (Input.GetMouseButtonUp(1)) {
            transform.localPosition = hipFire;
            if (isAiming) {
                isAiming = false;
                UpCurs.transform.position += deltaY;
                DownCurs.transform.position -= deltaY;
                LeftCurs.transform.position -= deltaX;
                RightCurs.transform.position += deltaX;
            }
        }
	}
}
