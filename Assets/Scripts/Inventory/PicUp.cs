using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicUp : MonoBehaviour
{
    private Inventory Invertory;
    public GameObject slotButton;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        Invertory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            for (int i = 0; i < Invertory.slots.Length; i++)
            {
                if (Invertory.IsFuul[i] == false)
                {
                    Invertory.IsFuul[i] = true;

                    Instantiate(slotButton, Invertory.slots[i].transform);
                    //   iv.Save(id, 1);
                    Slot slot = Invertory.slots[i].GetComponent<Slot>();
          
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
