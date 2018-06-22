using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;
    public GameObject LeaveAmmo;
    public GameObject HeldGun;
    public GameObject Blood;
    public GameObject Chest;
    public Follow followScript;
    public bool isDead = false;
    float waitDrop;

    void Start() {
        followScript = GetComponent<Follow>();
    }

    void Update() {
        if(health <= 0 && !isDead) {
            isDead = true;
            waitDrop = followScript.Die();
            StartCoroutine(AmmoAndBloodDrop());
        }
    }

    public void TakeDamage(float amount) {
        health -= amount;
        /*if(health <= 0 && !isDead) {
            isDead = true;
            LeaveAmmo.SetActive(true);
            Blood.SetActive(true);
            //Die();
            followScript.Die();
        }*/
    }

    IEnumerator AmmoAndBloodDrop() {
        yield return new WaitForSeconds(waitDrop);
        Blood.transform.position = new Vector3(Chest.transform.position.x, Blood.transform.position.y, Chest.transform.position.z);
        LeaveAmmo.transform.position = new Vector3(HeldGun.transform.position.x, LeaveAmmo.transform.position.y, HeldGun.transform.position.z);
        HeldGun.SetActive(false);
        LeaveAmmo.SetActive(true);
        Blood.SetActive(true);
    }
}



