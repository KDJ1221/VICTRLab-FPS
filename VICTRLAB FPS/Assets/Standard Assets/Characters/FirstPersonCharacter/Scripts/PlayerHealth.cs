using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour {
    private double maxHealth = 100;
    private Boolean gettingHit = false;
    private float hitTimer = 0.0f;
    double playerHealth = 100;
    double bloodOpacity = 0;
    double splatterOpacity_1 = 0;
    double splatterOpacity_2 = 0;
    double splatterOpacity_3 = 0;
    double splatterOpacity_4 = 0;
    double DamageOpacity = 0;
    public GameObject HealthDisplay;
    public RawImage bloodColor_1;
    public RawImage bloodColor_2;
    public RawImage bloodColor_3;
    public RawImage bloodColor_4;
    public RawImage bloodColor_5;
    public RawImage bloodSplatter_1;
    public RawImage bloodSplatter_2;
    public RawImage bloodSplatter_3;
    public RawImage bloodSplatter_4;
    public RawImage DamageIndicator;
    public Transform indicator;
    public Transform cameraTransform;
    private AudioSource[] sounds;
    private AudioSource source;
    private AudioSource audioHB140;
    private AudioSource audioHB210;
    public AudioClip heartBeat140;
    public AudioClip heartBeat210;



    void Start() {
        indicator = DamageIndicator.rectTransform;
        sounds = GetComponents<AudioSource>();
        source = sounds[0];
        audioHB140 = sounds[1];
        audioHB210 = sounds[2];
    }

    void Update () {
        playHeartBeat();
        hitTimer += Time.deltaTime;
        if (hitTimer > 5.0f)
        {
            gettingHit = false;
        }


        Debug.Log(playerHealth);
        //Health regenerating in real time
        if(playerHealth >= 0 && gettingHit == false)
        {
            playerHealth += Time.deltaTime * 5;
        }

        //Ensures player health is never more than max health
        if(playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        if(bloodOpacity > 0 && gettingHit == false)
        {
            bloodOpacity -= Time.deltaTime * 8;
        }

        if (splatterOpacity_1 > 0 && gettingHit == false) {
            splatterOpacity_1 -= Time.deltaTime * 10;
        }
        if(splatterOpacity_2 > 0 && gettingHit == false) {
            splatterOpacity_2 -= Time.deltaTime * 10;
        }
        if(splatterOpacity_3 > 0 && gettingHit == false) {
            splatterOpacity_3 -= Time.deltaTime * 10;
        }
        if(splatterOpacity_4 > 0 && gettingHit == false) {
            splatterOpacity_4 -= Time.deltaTime * 10;
        }

        if(playerHealth > 90) {
            bloodOpacity = 0;
            splatterOpacity_1 = 0;
            splatterOpacity_2 = 0;
            splatterOpacity_3 = 0;
            splatterOpacity_4 = 0;
        }

        if (!gettingHit && playerHealth < 90 && playerHealth > 60)
        {
            bloodOpacity = 40;
        }

        if (DamageOpacity > 0 && Time.timeScale == 1) {
            DamageOpacity -= 5;
        }
        else if (DamageOpacity <= 0 && Time.timeScale == 1) {
            DamageOpacity = 0;
        }

        Debug.Log(bloodOpacity + "," + splatterOpacity_1 + "," + splatterOpacity_2 + "," + 
            splatterOpacity_3 + "," + splatterOpacity_4);

        HealthDisplay.GetComponent<Text>().text = "" + (int) playerHealth;
        Color color;
        Color colorSplatter_1, colorSplatter_2, colorSplatter_3, colorSplatter_4, colorDamage;
        color = new Color32(0, 0, 0, (byte) bloodOpacity);
        colorSplatter_1 = new Color32(0, 0, 0, (byte) splatterOpacity_1);
        colorSplatter_2 = new Color32(0, 0, 0, (byte) splatterOpacity_2);
        colorSplatter_3 = new Color32(0, 0, 0, (byte) splatterOpacity_3);
        colorSplatter_4 = new Color32(0, 0, 0, (byte) splatterOpacity_4);
        colorDamage = new Color32(0, 0, 0, (byte) DamageOpacity);
        bloodColor_1.color = new Color(bloodColor_1.color.r, bloodColor_1.color.g, bloodColor_1.color.b, color.a);
        bloodColor_2.color = new Color(bloodColor_2.color.r, bloodColor_2.color.g, bloodColor_2.color.b, color.a);
        bloodColor_3.color = new Color(bloodColor_3.color.r, bloodColor_3.color.g, bloodColor_3.color.b, color.a);
        bloodColor_4.color = new Color(bloodColor_4.color.r, bloodColor_4.color.g, bloodColor_4.color.b, color.a);
        bloodColor_5.color = new Color(bloodColor_5.color.r, bloodColor_5.color.g, bloodColor_5.color.b, color.a);
        bloodSplatter_1.color = new Color(bloodSplatter_1.color.r, bloodSplatter_1.color.g, bloodSplatter_1.color.b, colorSplatter_1.a);
        bloodSplatter_2.color = new Color(bloodSplatter_2.color.r, bloodSplatter_2.color.g, bloodSplatter_2.color.b, colorSplatter_2.a);
        bloodSplatter_3.color = new Color(bloodSplatter_3.color.r, bloodSplatter_3.color.g, bloodSplatter_3.color.b, colorSplatter_3.a);
        bloodSplatter_4.color = new Color(bloodSplatter_4.color.r, bloodSplatter_4.color.g, bloodSplatter_4.color.b, colorSplatter_4.a);
        DamageIndicator.color = new Color(DamageIndicator.color.r, DamageIndicator.color.g, DamageIndicator.color.b, colorDamage.a);
    }

    public void TakeDamage(float amount) {
        gettingHit = true;
        hitTimer = 0.0f;
        playerHealth -= amount;

        if (playerHealth < 0) {
            playerHealth = 1;
        }

        if(playerHealth <= 10) {
            bloodOpacity = 180;
            splatterOpacity_1 = 200;
            splatterOpacity_2 = 200;
            splatterOpacity_3 = 200;
            splatterOpacity_4 = 200;
        }
        else if(playerHealth <= 30) {
            bloodOpacity = 150;
            splatterOpacity_3 = 200;
            splatterOpacity_2 = 200;
            splatterOpacity_1 = 200;
        }
        else if(playerHealth <= 60) {
            bloodOpacity = 80;
            splatterOpacity_2 = 200;
            splatterOpacity_1 = 200;

        }
        else if(playerHealth < 90) {
            bloodOpacity = 40;
            splatterOpacity_1 = 255;
            splatterOpacity_2 = 255;
        }

        if (playerHealth < 100) {
            DamageOpacity = 255;
        }
    }

    public void DamageDirection(Transform enemyTransform) {
        Vector3 relativePos = enemyTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        float rot = Quaternion.Angle(rotation, transform.localRotation);
        if (Vector3.Dot(transform.right, relativePos) > 0f) {
            rot = -rot;
        }
        indicator.transform.localRotation = Quaternion.Euler(0, 0, rot);
    }

    public void playHeartBeat()
    {
        if (playerHealth < 90 && playerHealth > 60)
        {
            
            if (audioHB210.isPlaying)
                audioHB210.Stop();
            if (!audioHB140.isPlaying)
                audioHB140.Play();
                
        }
        else if (playerHealth <= 60)
        {
            if (audioHB140.isPlaying)
                audioHB140.Stop();
            if (!audioHB210.isPlaying)
                audioHB210.Play();
        }
        else
        {
            if (audioHB140.isPlaying)
                audioHB140.Stop();
            if (audioHB210.isPlaying)
                audioHB210.Stop();

        }
    }
}
