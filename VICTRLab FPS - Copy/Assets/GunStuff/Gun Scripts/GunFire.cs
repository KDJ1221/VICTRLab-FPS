﻿
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;

    public GameObject muzzle1;
    public GameObject muzzle2;

    public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")&& Time.time >= nextTimeToFire) {
            AudioSource gunsound = GetComponent<AudioSource>();
            gunsound.Play();
            GetComponent<Animation>().Play("GunShot");

            nextTimeToFire = Time.time + 1f / fireRate;
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

            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            }

        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);
        muzzle1.SetActive(true);
        muzzle2.SetActive(true);

        }
	}