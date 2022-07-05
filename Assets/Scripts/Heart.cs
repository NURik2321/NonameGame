using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int heealf;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            HealfSystemPL healfSystemPL = collision.collider.GetComponent<HealfSystemPL>();
            healfSystemPL.healf = healfSystemPL.healf + heealf;
        }
    }
}
