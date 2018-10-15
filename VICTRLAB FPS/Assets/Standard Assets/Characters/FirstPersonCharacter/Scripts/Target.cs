using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public static int enemyCount = 6;
    public static int totalCount;
    public int totalInspector;
    public float health = 50f;
    public GameObject LeaveAmmo;
    public GameObject HeldGun;
    public GameObject Blood;
    public GameObject Chest;
    public Follow followScript;
    public bool isDead = false;
    float waitDrop;
    CapsuleCollider cc;

    void Start() {
        followScript = GetComponent<Follow>();
        cc = GetComponent<CapsuleCollider>();
        totalCount = totalInspector;
    }

    void Update() {
        if (health <= 0 && !isDead) {
            isDead = true;
            waitDrop = followScript.Die();
            StartCoroutine(AmmoAndBloodDrop());
            enemyCount--;
            totalCount--;
            if (enemyCount <= 0) {
                enemyCount = 6;
                followScript.ChangeDamage("reset");
            }
            else {
                followScript.ChangeDamage("raise");
                //Debug.Log(enemyCount);
            }
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
        cc.enabled = false;
        yield return new WaitForSeconds(waitDrop);
        Blood.transform.position = new Vector3(Chest.transform.position.x, Blood.transform.position.y, Chest.transform.position.z);
        HeldGun.SetActive(false);
        LeaveAmmo.SetActive(true);
        Blood.SetActive(true);
    }

    public int GetCount() {
        return enemyCount;
    }

    public void ResetCount() {
        enemyCount = 6;
        followScript.ammo = UnityEngine.Random.Range(1, 15);
        followScript.ChangeDamage("reset");
    }

    public int GetTotalCount() {
        return totalCount;
    }
}