using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourAnimMG : MonoBehaviour
{
    PlayerMove playerMove;

    Animator animator;
    Vector3 vector3;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<PlayerMove>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vector3 = playerMove.movement;

        if (vector3 != Vector3.zero) { 
            animator.SetFloat("Horizontal", vector3.x);
            animator.SetFloat("Vertical", vector3.y);
        }
    }
}
