using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotEqpetment : MonoBehaviour, IDropHandler
{

    public int Strong;
    public int smart;
    public int agility;
    public int PhysicsDamage;


    public string type;

    public int index;

    PlayerAttack playerAttack;


    private Inventory inventory;

    private PlayerVaribies playerVaribies;

    ItemEqpent itemEqpent;


 
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<ItemEqpent>()!=null)
        {
             if (!inventory.isFullSlotEqpetment[index] && eventData.pointerDrag.GetComponent<ItemEqpent>().type == type )
          {
               
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;

            }
        }
       
    }



    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        playerVaribies = FindObjectOfType<PlayerVaribies>();
        playerAttack = FindObjectOfType<PlayerAttack>();


    }

    


    private void OnTransformChildrenChanged()
    {


        itemEqpent = GetComponentInChildren<ItemEqpent>();

       
        
            if (itemEqpent !=null)
            {
            playerVaribies.strong += itemEqpent.strong;
            Strong = itemEqpent.strong;

            playerVaribies.smarts += itemEqpent.smarts;
            smart = itemEqpent.smarts;

            playerVaribies.agility += itemEqpent.agility;
            agility = itemEqpent.agility;

           playerAttack.PhyDamage += itemEqpent.PhysicsDamage;
            PhysicsDamage = itemEqpent.PhysicsDamage;
        }

            else
            {


            playerVaribies.strong -= Strong;
            playerVaribies.smarts -= smart;
            playerVaribies.agility -= agility;
            playerAttack.PhyDamage -= PhysicsDamage;


        }





    }


    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFullSlotEqpetment[index] = false;
        }

        else
        {
            inventory.isFullSlotEqpetment[index] = true;
        }
    }

}
