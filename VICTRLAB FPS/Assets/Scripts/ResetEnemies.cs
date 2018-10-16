using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEnemies : MonoBehaviour {
    public GameObject enemy;
    public int count;
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            if (enemy.GetComponent<Target>().GetCount() <= 0) {
                enemy.GetComponent<Target>().ResetCount(count);
                //Debug.Log("Enemies reset");
            }
            /*else {
                Debug.Log("enemies not reset");
            }*/
        }
    }
}
