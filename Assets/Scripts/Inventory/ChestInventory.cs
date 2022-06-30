using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestInventory : MonoBehaviour
{

    public List<GameObject> items;

    public GameObject[] slots;

    public int size;

    public bool[] isFuul;


    public GameObject Panel;

    public string[] names;
    public int indexChest;

    public GameObject PanelinChest;
    //private void OnTriggerStay2D(Collider2D collision)
    //{



    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {

          Panel.SetActive(true);


        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = GameObject.Find("SlotInChest " + i);
        }

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<SlotInChest>().chestInventory1 = this;

            }

            for (int i = 0; i < names.Length; i++)
            {
                items[i] = Resources.Load<GameObject>(names[i]);
            }
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] !=null)
                {
                    slots[i].GetComponent<SlotInChest>().Toogle(this);

                }
            }

           

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].transform.childCount != 0)
                {

                    names[i] = slots[i].transform.GetChild(0).GetComponent<Item>().pathPrefab;


                    Destroy(slots[i].transform.GetChild(0).gameObject);

                }

                else
                {
                    names[i] = "";
                }
            }



        Panel.SetActive(false);

    }
    }


    //public void Save()
    //{
    //    PlayerPrefs.SetString("ItemInChest"+indexChest, JsonUtility.ToJson(items));
    //}

    //public void Load()
    //{
    //    items = JsonUtility.FromJson<List<GameObject>>(PlayerPrefs.GetString("ItemInChest" + indexChest)) ;
    //}
}
