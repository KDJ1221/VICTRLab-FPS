
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.Play();
            GetComponent<Animation>().Play("GunShot");

            Shoot();
        }

        }
        public void Shoot(){

            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
                Debug.Log(hit.transform.name);
            }
        }
	}
