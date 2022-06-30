using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SlotInChest : MonoBehaviour, IDropHandler
{

    public int index;

    Inventory inventory;

  public  ChestInventory chestInventory1;
    
    public void Toogle(ChestInventory chestInventory)
    {
        if (chestInventory.items[index]!=null)
        {
            Instantiate(chestInventory.items[index], transform);

        }

    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {

        if (!chestInventory1.isFuul[index])
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
        if (chestInventory1 !=null)
        {
            if (transform.childCount <= 0)
            {
                chestInventory1.isFuul[index] = false;
            }

            else
            {
                chestInventory1.isFuul[index] = true;
            }
        }

        
    }
}
