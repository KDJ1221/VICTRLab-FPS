using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {

    public AudioSource ReloadSound;
    //public GameObject CrossObject;
    //public GameObject MechanicsObject;
    public int ClipCount;
    public int ReserveCount;
    public int ReloadAvailable;
    public static GunFire GunComponent;
    public static AimDownSights aimScript;

	void Start () {
        GunComponent = GetComponent<GunFire>();
        aimScript = GetComponent<AimDownSights>();
    }
	
	// Update is called once per frame
	void Update () {
        ClipCount = GlobalAmmo.LoadedAmmo;
        ReserveCount = GlobalAmmo.CurrentAmmo;
        if(ReserveCount == 0) {
            ReloadAvailable = 0;
        }
        else {
            ReloadAvailable = 20 - ClipCount;
        }

        if(Input.GetButtonDown("Reload")) {
            if(ReloadAvailable >= 1) {
                if(ReserveCount <= ReloadAvailable) {
                    GlobalAmmo.LoadedAmmo += ReserveCount;
                    GlobalAmmo.CurrentAmmo -= ReserveCount;
                }
                else {
                    GlobalAmmo.LoadedAmmo += ReloadAvailable;
                    GlobalAmmo.CurrentAmmo -= ReloadAvailable;
                }
                ActionReload();
            }
            StartCoroutine(EnableScripts());
        }
	}

    IEnumerator EnableScripts() {
        yield return new WaitForSeconds(1.1f);
        //aimScript.StopAim();
        aimScript.enabled = true;
        GunComponent.enabled = true;
        //CrossObject.SetActive(true);
        //MechanicsObject.SetActive(true);
    }

    void ActionReload() {
        GunComponent.enabled = false;
        aimScript.StopAim();
        aimScript.enabled = false;
        //CrossObject.SetActive(false);
        //MechanicsObject.SetActive(false);
        ReloadSound.Play();
        GetComponent<Animation>().Play("Reload");
    }
}