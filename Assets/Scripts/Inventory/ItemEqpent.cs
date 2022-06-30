using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEqpent : MonoBehaviour
{

    public string type;

    public int smarts;
    public int strong;
    public int agility;
    public int PhysicsDamage;
    public bool isEqpet;



   
    private void Update()
    {
        if (gameObject.GetComponentInParent<SlotEqpetment>()!=null)
        {
            isEqpet = true;
        }

        else
        {
            isEqpet = false;
        }


    }

   
}
