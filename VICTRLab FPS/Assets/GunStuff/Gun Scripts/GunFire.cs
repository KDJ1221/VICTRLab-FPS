
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;

    public GameObject muzzle1;
    public GameObject muzzle2;
    
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

           // muzzleFlash.Play();

            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
                Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) {
                target.TakeDamage(damage);
            }

            }
        muzzle1.SetActive(true);
        muzzle2.SetActive(true);

        }
	}
