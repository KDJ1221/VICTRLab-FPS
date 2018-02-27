
using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour {

    public float damage;
    public float range;
    public float fireRate;
    public float impactForce;

    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;

    public GameObject muzzle1;
    public GameObject muzzle2;

    public GameObject impactEffect;
    public GameObject bloodEffect;

    private float nextTimeToFire = 0.0F;
    AudioSource gunSound;
    WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    void Start() {
        gunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if(GlobalAmmo.LoadedAmmo >= 1) {
            if(Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire) {
                nextTimeToFire = Time.time + fireRate;
                StartCoroutine(Fire());
                Shoot();
            }
        }
        Debug.Log(nextTimeToFire);
    }

    public void Shoot() {
        // muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        if(hit.transform.tag == "Enemy") {
            GameObject impactGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.3f);
        }
        else {
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
        muzzle1.SetActive(true);
        muzzle2.SetActive(true);
    }

    public IEnumerator Fire() {
        GlobalAmmo.LoadedAmmo -= 1;
        //AudioSource gunsound = GetComponent<AudioSource>();
        gunSound.Play();
        GetComponent<Animation>().Play("GunShot");
        yield return shotDuration;
    }
}