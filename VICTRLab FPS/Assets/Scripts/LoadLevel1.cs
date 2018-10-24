using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel1 : MonoBehaviour {
    public string sceneName;
    public GameObject enemy;
    public Image errorPanel;
    public Text errorText;
    double opacity = 0;

    void Update() {
        Color color;
        color = new Color32(0, 0, 0, (byte)opacity);
        if (opacity >= 0) {
            errorPanel.color = new Color(errorPanel.color.r, errorPanel.color.g, errorPanel.color.b, color.a);
            errorText.color = new Color(errorText.color.r, errorText.color.g, errorText.color.b, color.a);
            opacity--;
        }
    }
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            if (enemy.GetComponent<Target>().GetTotalCount() > 0) {
                opacity = 173;
            }
            else {
                PersistentManagerScript.Instance.loadScene = sceneName;
                SceneManager.LoadScene("LoadingScreen");
            }
        }
    }
}
