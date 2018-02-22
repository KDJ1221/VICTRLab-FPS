
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;
    public GameObject LeaveAmmo;

    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0) {
            LeaveAmmo.SetActive(true);
            Die();
        }
    }


    void Die() {
        Destroy(gameObject);
    }


    }



