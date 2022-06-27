using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public float trust;
    public float KnockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
             Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb!=null)
            {
                rb.GetComponent<Enemy_base>().Curretstate = Enemy_base.State.stagger;
                Vector2 defference = rb.transform.position - transform.position;
                defference = defference.normalized * trust;
                rb.AddForce(defference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(rb));
            }
        }
    }


   private IEnumerator KnockCo(Rigidbody2D rb)
    {
        if (rb != null)
        {
            yield return new  WaitForSeconds(KnockTime);
            rb.velocity = Vector2.zero;
            rb.GetComponent<Enemy_base>().Curretstate = Enemy_base.State.idle;

        }
    }
}
