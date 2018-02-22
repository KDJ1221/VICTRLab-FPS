
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;
    public GameObject LeaveAmmo;
    public int whichBlood;
    public GameObject Blood;
    public Vector3 fallDownPos;
    public Quaternion fallDownRot;

    public void TakeDamage(float amount) {
        health -= amount;
        if(health <= 0) {
            LeaveAmmo.SetActive(true);
            Blood.SetActive(true);
            //Die();
            fallDown();
        }
    }

    void Die() {
        Destroy(gameObject);
    }

    void fallDown() {
        transform.position = fallDownPos;
        transform.rotation = fallDownRot;
    }
}



