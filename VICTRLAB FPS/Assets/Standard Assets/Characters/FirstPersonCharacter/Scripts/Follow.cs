using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Follow : MonoBehaviour
{
    //remember to make variables for numbers so they aren't just hard coded 
    public Transform Player;
    public Vector3 newPosition;
    public Vector3 origPosition;
    private static float damage = 0.7f;
    private float bossDamage = 3.0f;
    public int ammo;
    private Animator anim; //animations weren't working because it was static instead of private
    bool isDead = false;
    bool isSquat = false;
    bool reload = false;
    bool canShoot = false;
    bool beginShoot = false;
    private static bool enemyOnStairs = false;
    float t;
    //float rdm;
    float shootTime;
    public Target targetScript;
    public CapsuleCollider cc;
    private GameObject playerTarget;
    public Vector3 direction;
    RaycastHit rayHit;
    public AudioClip enemyShot;
    AudioSource audioSource;
    public bool isBoss;
    public bool isMG;


    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        //rdm = UnityEngine.Random.Range(10, 20);
        shootTime = UnityEngine.Random.Range(0, 3);
        //t = Time.time + rdm;
        targetScript = GetComponent<Target>();
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        cc = GetComponent<CapsuleCollider>();
        ammo = 15;
        //audioSource.clip = GetComponent<AudioClip>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(enemyShot);
    }

    // Update is called once per frame
    void Update() {
        //Vector3 playerDir = Player.position - transform.position;
        //Debug.Log("playerDir is " + playerDir);
        //float angle = Vector3.Angle(playerDir, Player.transform.forward);
        //Debug.Log("angle is " + angle);
        //if (Mathf.Abs(angle) < 5.0f)
        //{
        //    anim.SetBool("isShooting", false);
        //    anim.SetBool("isIdle", false);
        //    anim.SetBool("isCrouch", true);
        //    isSquat = true;
        //    Debug.Log("I'm looking at the enemy so he should crouch");
        //}

        Vector3 forward = Player.transform.forward;
        Vector3 toOther = (this.transform.position - Player.transform.position).normalized;
        float check = Vector3.Dot(forward, toOther);
        float distance = Vector3.Distance(Player.position, this.transform.position);
        //Debug.Log("The distance is: " + distance);
        //Debug.Log(ammo);

        if (reload) {
            reload = false;
            //Debug.Log(ammo);
            ChangeState("Reload");
            ammo = 60;
            //Debug.Log(ammo);
        }

        else if (Physics.Raycast(transform.position, transform.forward, out rayHit, 100)) {
            if (check > 0.97f && targetScript.GetCount() > 3 && distance > 2.0f && rayHit.transform.gameObject != playerTarget && !isBoss) {
                anim.SetBool("isCrouch", true);
                anim.SetBool("isShooting", false);
                anim.SetBool("isIdle", false);
                cc.height = 0.5f;
                isSquat = true;
            }


            else {
                //Debug.Log("Not facing the object" + check);

                //Debug.Log("enemy count is " + targetScript.GetCount());
                anim.SetBool("isCrouch", false);
                //anim.SetBool("isShooting", true);
                anim.SetBool("isIdle", false);
                cc.height = 2f;
                isSquat = false;
                //Attack();

                if (Math.Abs(Player.position.y - this.transform.position.y) <= 5) {
                    if (Math.Abs(Player.position.y - this.transform.position.y) > 1 && !enemyOnStairs) {
                        enemyOnStairs = true;
                        damage += 0.5f;
                    }
                    else if (Math.Abs(Player.position.y - this.transform.position.y) <= 1 && enemyOnStairs) {
                        enemyOnStairs = false;
                        damage -= 0.5f;
                    }
                    StartCoroutine("StartShoot");
                    if (Math.Abs(Player.position.x - this.transform.position.x) < 25) {
                        if (!isDead && beginShoot) {
                            direction = Player.position - this.transform.position;
                            if (Math.Abs(Player.position.y - this.transform.position.y) <= 1)
                                direction.y = 0;
                            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                            anim.SetBool("isIdle", false);
                            anim.SetBool("isCrouch", false);

                            if (direction.magnitude > 0) {
                                anim.SetBool("isShooting", true);
                                anim.SetBool("isIdle", false);
                                Attack();

                            }
                            else {
                                //anim.SetBool("isIdle", true);
                                anim.SetBool("isShooting", true);
                            }
                        }
                    }
                    else {
                        anim.SetBool("isIdle", true);
                    }
                }
            }
        }
        if (isDead) {
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
    }


    //my work above

    public float Die() {
        anim.SetBool("isCrouch", false);
        anim.SetBool("isIdle", false);
        anim.SetBool("isShooting", false);
        anim.SetBool("isReload", false);
        anim.SetBool("isDead", true);
        isDead = true;
        if (isSquat) {
            return 2.5f;
        }
        return 4.0f;
    }

    /*public IEnumerator WaitNoSquat() {
        yield return new WaitForSeconds(2.0f + rdm);
        isSquat = false;
    }*/

    public IEnumerator GunCoolDown() {
        yield return new WaitForSeconds(3.5f);
        canShoot = true;
    }

    public IEnumerator GunCoolDownMG() {
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
    }

    public IEnumerator WaitReload() {
        yield return new WaitForSeconds(2.0f);
        reload = true;
    }

    public IEnumerator StartShoot() {
        yield return new WaitForSeconds(shootTime);
        beginShoot = true;
    }

    public void ChangeState(string s) {
        /*if (s.Equals("Squat")) {
            if (isSquat) {
                if (Math.Abs(Player.position.x - this.transform.position.x) < 25 && !isDead && !isSquat) {
                    Vector3 direction = Player.position - this.transform.position;
                    if (direction.magnitude > 0) {
                        anim.SetBool("isIdle", false);
                        anim.SetBool("isShooting", true);
                    }
                    else {
                        anim.SetBool("isShooting", false);
                        anim.SetBool("isIdle", true);
                    }
                }
                anim.SetBool("isCrouch", false);
                StartCoroutine("WaitNoSquat");
            }
            else {
                isSquat = true;
                anim.SetBool("isShooting", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isCrouch", true);
            }
        }*/
        if (s.Equals("Reload")) {
            anim.SetBool("isReload", false);
            anim.SetBool("isShooting", true);
        }
    }

    void Attack() {
        if (rayHit.transform.gameObject == playerTarget) {
            PlayerHealth target = rayHit.transform.GetComponent<PlayerHealth>();
            if (target != null && canShoot) {
                GetComponent<AudioSource>().Play();
                canShoot = false;
                float rdm = UnityEngine.Random.value;
                float missPercent = (rayHit.distance + 60) / 100;
                //Debug.Log(missPercent);
                if ((rdm > missPercent || rayHit.distance <= 1) && ammo > 0) {
                    target.DamageDirection(GetComponent<Transform>());
                    if (isBoss) {
                        target.TakeDamage(bossDamage);
                    }
                    else {
                        target.TakeDamage(damage);
                    }
                    ammo--;
                    if (ammo <= 0) {
                        anim.SetBool("isShooting", false);
                        anim.SetBool("isReload", true);
                        StartCoroutine("WaitReload");
                        //Debug.Log(reload);
                    }
                }
            }
            else {
                //Debug.Log("start coroutine");
                if (isMG) {
                    StartCoroutine("GunCoolDownMG");
                }
                else {
                    StartCoroutine("GunCoolDown");
                }
            }
        }
        //}
    }

    public void ChangeDamage(string change) {
        if (change.Equals("raise")) {
            damage += 0.7f;
        }
        else if (change.Equals("reset")) {
            damage = 0.7f;
            //Debug.Log(damage);
        }
    }
}
