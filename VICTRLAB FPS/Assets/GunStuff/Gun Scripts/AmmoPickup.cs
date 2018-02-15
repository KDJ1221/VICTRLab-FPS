using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

    public int AmmoAmount;
    public AudioSource AmmoSound;

    void OnTriggerEnter (Collider other) {
        AmmoSound.Play();
        if (GlobalAmmo.LoadedAmmo == 0 && AmmoAmount == 10)
            GlobalAmmo.LoadedAmmo += AmmoAmount;
        else if (GlobalAmmo.LoadedAmmo == 0 && AmmoAmount > 10)
        {
            GlobalAmmo.LoadedAmmo = AmmoAmount - 10;
            AmmoAmount -= 10;
            GlobalAmmo.CurrentAmmo += AmmoAmount;
        }
        else
        {
            GlobalAmmo.CurrentAmmo += AmmoAmount;
        }
        this.gameObject.SetActive(false);
        
	}
}
