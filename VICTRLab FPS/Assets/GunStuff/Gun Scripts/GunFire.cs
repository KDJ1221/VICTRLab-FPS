
using UnityEngine;
using UnityEngine.UI;
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

    public RawImage UpCurs;
    public RawImage DownCurs;
    public RawImage LeftCurs;
    public RawImage RightCurs;
    public GameObject CursObj;

    public float missPercent;
    public int missConstant;

    void Start() {
        gunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        RaycastHit aim;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out aim, range)) {
            if(aim.transform.tag == "Enemy") {
                UpCurs.color = Color.red;
                DownCurs.color = Color.red;
                RightCurs.color = Color.red;
                LeftCurs.color = Color.red;
            }
            else {
                UpCurs.color = Color.white;
                DownCurs.color = Color.white;
                RightCurs.color = Color.white;
                LeftCurs.color = Color.white;
            }
        }
        else {
            UpCurs.color = Color.white;
            DownCurs.color = Color.white;
            RightCurs.color = Color.white;
            LeftCurs.color = Color.white;
        }
        if(GlobalAmmo.LoadedAmmo >= 1) {
            if(Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire) {
                nextTimeToFire = Time.time + fireRate;
                StartCoroutine(Fire());
                Shoot();
            }
        }
    }

    public void Shoot() {
        // muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
            Debug.Log(hit.distance);
            if(CursObj.transform.position.y < 267.5) {
                missConstant = 5;
            }
            else if(CursObj.transform.position.y > 267.5) {
                missConstant = 20;
            }
            else {
                missConstant = 10;
            }
            missPercent = (hit.distance + missConstant) / 100;
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) {
                float rdm = Random.value;
                /*Debug.Log("rdm");
                Debug.Log(rdm);
                Debug.Log("Miss Percent");
                Debug.Log(missPercent);
                Debug.Log("position");
                Debug.Log(CursObj.transform.position.y);*/
                if(rdm > missPercent || hit.distance <= 5) {
                    target.TakeDamage(damage);
                }
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