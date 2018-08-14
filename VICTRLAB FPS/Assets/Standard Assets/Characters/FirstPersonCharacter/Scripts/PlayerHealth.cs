using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
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

    void Start() {
        indicator = DamageIndicator.rectTransform;
    }

    void Update () {
        if(playerHealth < 100) {
            playerHealth += 0.05;
        }
        if(bloodOpacity > 0) {
            bloodOpacity -= 0.2;
        }
        if(splatterOpacity_1 > 0) {
            splatterOpacity_1 -= 0.8;
        }
        if(splatterOpacity_2 > 0) {
            splatterOpacity_2 -= 0.6;
        }
        if(splatterOpacity_3 > 0) {
            splatterOpacity_3 -= 0.4;
        }
        if(splatterOpacity_4 > 0) {
            splatterOpacity_4 -= 0.2;
        }
        if(DamageOpacity > 0) {
            DamageOpacity -= 5;
        }
        else if (DamageOpacity <= 0) {
            DamageOpacity = 0;
        }

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
        playerHealth -= amount;

        if (playerHealth < 0) {
            playerHealth = 1;
        }

        if(playerHealth <= 10) {
            bloodOpacity = 255;
            splatterOpacity_1 = 255;
            splatterOpacity_2 = 255;
            splatterOpacity_3 = 255;
            splatterOpacity_4 = 255;
        }
        else if(playerHealth <= 30) {
            bloodOpacity = 150;
            splatterOpacity_3 = 255;
            splatterOpacity_2 = 255;
            splatterOpacity_1 = 255;
        }
        else if(playerHealth <= 50) {
            bloodOpacity = 80;
            splatterOpacity_2 = 255;
            splatterOpacity_1 = 255;
        }
        else if(playerHealth <= 70) {
            splatterOpacity_1 = 255;
        }

        if (playerHealth < 100) {
            DamageOpacity = 255;
        }
        
        


    }

    public void DamageDirection(Transform enemyTransform) {
        Vector3 direction = Camera.main.WorldToScreenPoint(enemyTransform.transform.position);
        Vector3 point = Vector3.zero;

        point.z = Mathf.Atan2((indicator.transform.position.y - direction.y), (indicator.transform.position.x - direction.x)) * Mathf.Rad2Deg - 90;

        indicator.transform.rotation = Quaternion.Euler(point * -1);
    }

    /*private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Strong Enemy") {
            playerHealth -= 10;
            if(playerHealth < 0) {
                playerHealth = 1;
            }
         
            if(playerHealth <= 10) {
                bloodOpacity = 255;
            }
            else if(playerHealth <= 30) {
                bloodOpacity = 150;
            }
            else if(playerHealth <= 50) {
                bloodOpacity = 80;
            }
            if(other.gameObject.tag == "Strong Enemy") {
                playerHealth = -100;
            }
        }
    }*/
}
