using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroying_OBJ : MonoBehaviour
{
    Animator animator;



    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("HitPl"))
        {
            animator.SetTrigger("Co");
        }
    }



    void Des()
    {

        Destroy(gameObject);
    }
}
