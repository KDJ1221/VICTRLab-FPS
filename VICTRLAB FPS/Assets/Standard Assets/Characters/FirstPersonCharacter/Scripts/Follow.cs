using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    //remember to make variables for numbers so they aren't just hard coded 
    public Transform Player;
    public int damage = 50;
    private Animator anim; //animations weren't working because it was static instead of private

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(Player.position, this.transform.position) < 10) {
            Vector3 direction = Player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);

            if(direction.magnitude > 0) {
                anim.SetBool("isShooting", true);
                anim.SetBool("isIdle", false);
               // Attack();

            }
            else {
                //anim.SetBool("isIdle", true);
                anim.SetBool("isShooting", true);
                
            }
        } 
		
	}


    /*void Attack() {
        RaycastHit rayHit;
        
        Debug.Log("Attack");
        if(Physics.Raycast(transform.position, transform.forward, out rayHit, 100)) {
            GameObject bloodEffect = (GameObject)Instantiate(Resources.Load("Blood Effect"));
            Debug.Log(rayHit.transform.name);
            //rayHit.transform.SendMessage("DamagePlayer", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
    */
}  
