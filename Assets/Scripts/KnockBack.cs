using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public float trust;
    public float KnockTime;

    PlayerMove playerMove;


    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
             Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Enemy_base enemy = collision.GetComponent<Enemy_base>();

            if (rb!=null && playerMove.cuuretState == PlayerMove.State.fight)
            {
                rb.GetComponent<Enemy_base>().Curretstate = Enemy_base.State.stagger;
                Vector2 defference = rb.transform.position - transform.position;
                defference = defference.normalized * trust;
                rb.AddForce(defference, ForceMode2D.Impulse);



                if (enemy.healf <= 0)
                {
                    enemy.DEs();
                }
               
               
            }
        }
    }


   
}
