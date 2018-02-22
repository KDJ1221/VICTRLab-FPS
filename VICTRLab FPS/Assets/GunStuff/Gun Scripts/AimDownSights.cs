using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSights : MonoBehaviour {

    public Vector3 aimDownSight;
    public Vector3 hipFire;
    public float aimspeed = 0;
    public bool isAiming = false;
    public GameObject UpCurs;
    public GameObject DownCurs;
    public GameObject LeftCurs;
    public GameObject RightCurs;
    Vector3 deltaY = new Vector3(0, 10.0f, 0);
    Vector3 deltaX = new Vector3(10.0f, 0, 0);

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButton(1)) {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSight, aimspeed * Time.deltaTime);
            Aim();
        }

        if(Input.GetMouseButtonUp(1)) {
            transform.localPosition = hipFire;
            StopAim();
        }
	}

    public void Aim() {
        //transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSight, aimspeed * Time.deltaTime);
        if(!isAiming) {
            isAiming = true;
            UpCurs.transform.position -= deltaY;
            DownCurs.transform.position += deltaY;
            LeftCurs.transform.position += deltaX;
            RightCurs.transform.position -= deltaX;
        }
    }

    public void StopAim() {
        transform.localPosition = hipFire;
        if(isAiming) {
            isAiming = false;
            UpCurs.transform.position += deltaY;
            DownCurs.transform.position -= deltaY;
            LeftCurs.transform.position -= deltaX;
            RightCurs.transform.position += deltaX;
        }
    }
}
