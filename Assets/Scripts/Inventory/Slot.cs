using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private Inventory inventory;
    public int index;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (!inventory.IsFuul[index])
        {
        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
        }
        
    }


    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
           inventory.IsFuul[index] = false;
        }

        else
        {
            inventory.IsFuul[index]  = true;
        }
    }
}
