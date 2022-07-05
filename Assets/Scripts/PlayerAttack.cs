using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float PhyDamage;
    PlayerMove playerMove;


    PlayerVaribies playerVaribies;

    WarrioeSpellsMG spellsMG;
    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerVaribies = GetComponent<PlayerVaribies>();
        spellsMG = GetComponent<WarrioeSpellsMG>();
    }
   


    private void Update()
    {


        if (!spellsMG.isKriting)
        {



            if (playerMove.movement.x != 0 && playerMove.movement.y != 0)
            {
                PhyDamage = ((float)(playerVaribies.strong * 2 + playerVaribies.agility * 0.5) / 2);

            }
            else
            {

                PhyDamage = ((float)(playerVaribies.strong * 2 + playerVaribies.agility * 0.5));

            }

        }
    }


    
}
