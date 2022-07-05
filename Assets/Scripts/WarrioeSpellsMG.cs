using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarrioeSpellsMG : MonoBehaviour
{

    public GameObject[] Spells;



    PlayerAttack playerAttack;

    public bool isKriting;
    public float[] Waiters;


    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    void ShieldActive()
    {
        if (Waiters[0] <= 0 && Input.GetKey(KeyCode.Alpha1))
        {
            Instantiate(Spells[0], transform);
            Waiters[0] = 15;
        }
       
    }


    void PowerActive()
    {

        if (Waiters[1] <= 0 && Input.GetKey(KeyCode.Alpha2))
        {
            Instantiate(Spells[1], transform);
            Waiters[1] = 20;
        }
    }

    void Krit()
    {
        if (Waiters[2] <= 0 && Input.GetKey(KeyCode.Alpha3)) 
        { 
            isKriting = true;
            playerAttack.PhyDamage = playerAttack.PhyDamage * 2;
            Waiters[2] = 15;

        }
    }


    private void Update()
    {
        if (Waiters[0] >0)
        {
            Waiters[0] -= Time.deltaTime;
        }

        else if (Waiters[1] > 0)
        {
            Waiters[1] -= Time.deltaTime;

        }
        else if (Waiters[2] > 0)
        {
            Waiters[2] -= Time.deltaTime;

        }


        ShieldActive();
        PowerActive();
        Krit();
    }
}
