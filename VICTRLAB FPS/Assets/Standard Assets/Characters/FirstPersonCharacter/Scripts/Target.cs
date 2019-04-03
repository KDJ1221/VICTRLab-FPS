using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public static int enemyCount = 6;
    public static int totalCount;
    public int count;
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

    public AudioClip shotHitSoft;
    public AudioClip dyingSound;
    private AudioClip origSound; //Original AudioClip attached to AudioSource

    private AudioSource source;

    void Start() {
        followScript = GetComponent<Follow>();
        cc = GetComponent<CapsuleCollider>();
        totalCount = totalInspector;

        source = GetComponent<AudioSource>();
        origSound = source.clip;
    }

    void Update() {
        if (health <= 0 && !isDead) {
            isDead = true;

            //Play the dyingsound one time
            source.PlayOneShot(dyingSound, 1.0F);

            waitDrop = followScript.Die();
            StartCoroutine(AmmoAndBloodDrop());
            enemyCount--;
            totalCount--;
            Debug.Log(enemyCount);
            //followScript.ChangeDamage("raise");
            if (enemyCount <= 0) {
                //enemyCount = 6;
                //followScript.ChangeDamage("reset");
                ResetCount(count);

            }
            else {
                followScript.ChangeDamage("raise");
                //Debug.Log(enemyCount);
            }
        }
    }

    public void TakeDamage(float amount) {
        health -= amount;
        Debug.Log("Hit");
        source.PlayOneShot(shotHitSoft, 1.0F);
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

    public void ResetCount(int count) {
        enemyCount = count;
        followScript.ammo = UnityEngine.Random.Range(1, 15);
        followScript.ChangeDamage("reset");
        Debug.Log("reset Count");
        Debug.Log(count);
    }

    public void ResetTotalCount(int count) {
        totalCount = count;
    }

    public int GetTotalCount() {
        return totalCount;
    }
}