using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    private CharacterController characterCollider;
    private CapsuleCollider capCol;
    public float ControllerHeight;

    void Start()
    {
        characterCollider = GetComponent<CharacterController>();
        capCol = GetComponent<CapsuleCollider>();
    }

    public void change(bool isCrouching)
    {
        if (!isCrouching)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            characterCollider.height = 1.8f;
            characterCollider.radius = 0.5f;
            capCol.height = 2.3f;
            capCol.radius = 0.5f;
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            characterCollider.height = ControllerHeight;
            characterCollider.radius = 0.3f;
            capCol.height = 1.1f;
            capCol.radius = 0.3f;
        }
    }
}
