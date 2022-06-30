using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;

    PlayerVaribies pl;
    public void SpawnDroppedItem()
    {
        if (pl != null)
        {
            Vector2 playeros = new Vector2(pl.transform.position.x + 2, pl.transform.position.y);
            Instantiate(item, playeros, Quaternion.identity);
            Destroy(gameObject);

        }

    }
}
