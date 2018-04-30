using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    double playerHealth = 100;
    double bloodOpacity = 0;
    public GameObject HealthDisplay;
    public RawImage bloodSplatter_1;
    public RawImage bloodSplatter_2;
    public RawImage bloodSplatter_3;
    public RawImage bloodSplatter_4;

    // Update is called once per frame
    void Update () {
        if(playerHealth < 100) {
            playerHealth += 0.05;
        }
        if(bloodOpacity > 0) {
            bloodOpacity -= 0.2;
        }

        HealthDisplay.GetComponent<Text>().text = "" + (int) playerHealth;
        Color color;
        color = new Color32(0, 0, 0, (byte) bloodOpacity);
        bloodSplatter_1.color = new Color(bloodSplatter_1.color.r, bloodSplatter_1.color.g, bloodSplatter_1.color.b, color.a);
        bloodSplatter_2.color = new Color(bloodSplatter_1.color.r, bloodSplatter_1.color.g, bloodSplatter_1.color.b, color.a);
        bloodSplatter_3.color = new Color(bloodSplatter_1.color.r, bloodSplatter_1.color.g, bloodSplatter_1.color.b, color.a);
        bloodSplatter_4.color = new Color(bloodSplatter_1.color.r, bloodSplatter_1.color.g, bloodSplatter_1.color.b, color.a);

    }

    private void OnTriggerEnter(Collider other) {
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
    }
}
