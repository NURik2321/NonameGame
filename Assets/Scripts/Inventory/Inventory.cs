using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;
    public bool[] IsFuul;
    public GameObject Inv;
    bool IsOpen = false;

    
    public bool[] isFullSlotEqpetment;

    public SlotEqpetment[] slotEqpetments;



    void Start()
    {
        Inv = GameObject.FindGameObjectWithTag("InvertoryManager");
        for (int i = 0; i < slotEqpetments.Length; i++)
        {
            slotEqpetments[i] = GameObject.Find("SlotEqptment " + i).GetComponent<SlotEqpetment>();
        }

      
    }
    void Update()
    {
        Inv.SetActive(IsOpen);
        if (Input.GetKeyDown(KeyCode.I))
        {
            IsOpen = !IsOpen;
        }

        
    }

  





}
