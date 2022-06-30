using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroying_OBJ : MonoBehaviour
{
    Animator animator;

    public GameObject[] loot;

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
        int r = Random.Range(0, 2);

        Instantiate(loot[r], transform.position,Quaternion.identity);
        Destroy(gameObject);
    }



}
