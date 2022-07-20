using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSystem : MonoBehaviour
{
    public GameObject fireOBJ;
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy_base enemy_Base = collision.GetComponent<Enemy_base>();
            if (!enemy_Base.IfFires)
            {
                Instantiate(fireOBJ, collision.transform);
            }
            enemy_Base.IfFires = true;

        }
    }
}
