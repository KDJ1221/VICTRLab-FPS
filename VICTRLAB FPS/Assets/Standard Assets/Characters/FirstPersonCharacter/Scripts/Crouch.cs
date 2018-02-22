using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    private CharacterController characterCollider;
    public float ControllerHeight;

    void Start()
    {
        characterCollider = GetComponent<CharacterController>();
    }

    public void change(bool isCrouching)
    {
        if (!isCrouching)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            characterCollider.height = 1.8f;
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            characterCollider.height = ControllerHeight;
        }
    }
}
