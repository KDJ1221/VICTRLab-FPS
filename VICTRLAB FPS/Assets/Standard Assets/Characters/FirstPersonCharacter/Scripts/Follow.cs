using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Follow : MonoBehaviour {
    //remember to make variables for numbers so they aren't just hard coded 
    public Transform Player;
    public Vector3 newPosition;
    public Vector3 origPosition;
    private static float damage = 0.5f;
    private Animator anim; //animations weren't working because it was static instead of private
    bool isDead = false;
    bool isSquat = false;
    bool canShoot = false;
    public bool CharacterTypeSquat;
    bool similarHeight = false;
    float t;
    float rdm;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rdm = UnityEngine.Random.Range(10, 20);
        t = Time.time + rdm;
    }

    // Update is called once per frame
    void Update () {
        if(Math.Abs(Player.position.y - this.transform.position.y) <= 4.5) {
            if(Time.time > t && CharacterTypeSquat) {
                ChangeState();
                rdm = UnityEngine.Random.Range(10, 20);
                t = Time.time + rdm;
            }
            if(Math.Abs(Player.position.x - this.transform.position.x) < 25 && !isDead && !isSquat) {
                Vector3 direction = Player.position - this.transform.position;
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                anim.SetBool("isIdle", false);
                anim.SetBool("isCrouch", false);
                anim.SetBool("isWalking", false);

                if(direction.magnitude > 0) {
                    anim.SetBool("isShooting", true);
                    anim.SetBool("isIdle", false);
                    float rdm = UnityEngine.Random.Range(5, 10);
                    //Debug.Log(isSquat);
                    //Squat(rdm);
                    Attack();

                }
                else {
                    //anim.SetBool("isIdle", true);
                    anim.SetBool("isShooting", true);
                }
            }
        }
    }

    public float Die() {
        anim.SetBool("isDead", false);
        anim.SetBool("isIdle", false);
        anim.SetBool("isShooting", false);
        anim.SetBool("isDead", true);
        isDead = true;
        if(isSquat) {
            return 2.5f;
        }
        return 4.0f;
    }

    public IEnumerator WaitNoSquat() {
        yield return new WaitForSeconds(2.0f + rdm);
        isSquat = false;
    }

    public IEnumerator GunCoolDown()
    {
        yield return new WaitForSeconds(2.5f);
        canShoot = true;
    }

    public void ChangeState() {
        if(isSquat) {
            anim.SetBool("isIdle", true);
            if (Math.Abs(Player.position.x - this.transform.position.x) < 25 && !isDead && !isSquat) {
                Vector3 direction = Player.position - this.transform.position;
                if (direction.magnitude > 0) {
                    anim.SetBool("isShooting", true);
                    anim.SetBool("isIdle", false);
                }
            }
            anim.SetBool("isCrouch", false);
            StartCoroutine(WaitNoSquat());
        }
        else {
            isSquat = true;
            anim.SetBool("isShooting", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isCrouch", true);
        }
    }

    void Attack() {
        //Debug.Log(canShoot);
        RaycastHit rayHit;

        if(Physics.Raycast(transform.position, transform.forward, out rayHit, 100)) {
            //GameObject bloodEffect = (GameObject)Instantiate(Resources.Load("Blood Effect"));
            //Debug.Log(rayHit.transform.name);
            //rayHit.transform.SendMessage("DamagePlayer", damage, SendMessageOptions.DontRequireReceiver);
            PlayerHealth target = rayHit.transform.GetComponent<PlayerHealth>();
            if(target != null && canShoot) {
                canShoot = false;
                float rdm = UnityEngine.Random.value;
                float missPercent = (rayHit.distance + 70) / 100;
                if(rdm > missPercent || rayHit.distance <= 1) {
                    target.TakeDamage(damage);
                }
            }
            else {
                //Debug.Log("start coroutine");
                StartCoroutine("GunCoolDown");
            }
        }
    }

    public void ChangeDamage(string change) {
        if (change.Equals("raise")) {
            damage += 0.1f;
            Debug.Log(damage);
        }
        else if (change.Equals("reset")) {
            damage = 0.5f;
            Debug.Log(damage);
        }
    }
}  
