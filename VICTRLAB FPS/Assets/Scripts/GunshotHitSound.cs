using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshotHitSound : MonoBehaviour
{
    public AudioClip shotHitSoft;
    public AudioClip shotHitHard;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision", gameObject);
        source.PlayOneShot(shotHitSoft, 1F);
    }
}
