using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float PhyDamage;

    PlayerMove playerMove;



    PlayerVaribies playerVaribies;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerVaribies = GetComponent<PlayerVaribies>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && playerMove.cuuretState== PlayerMove.State.fight)
        {
            Enemy_base enemy_Base = collision.GetComponent<Enemy_base>();
            enemy_Base.healf -= PhyDamage;
        }
    }


    private void Update()
    {
        PhyDamage = ((float)(playerVaribies.strong * 2 + playerVaribies.agility * 0.5));
    }
}
