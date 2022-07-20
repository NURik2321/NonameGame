using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarrioeSpellsMG : MonoBehaviour
{

    public GameObject[] Spells;



    PlayerAttack playerAttack;

    public bool isKriting;
    public float[] Waiters;
    public float[] MaxWaiters;

    public Sprite[] sprites;
    public Image[] images;
    public Image[] BGimages;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();


        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = sprites[i];
            BGimages[i].sprite = sprites[i];
        }
    }

    void ShieldActive()
    {
        if (Waiters[0] <= 0 && Input.GetKey(KeyCode.Alpha1))
        {
            Instantiate(Spells[0], transform);
            Waiters[0] =MaxWaiters[0];
        }
                   images[0].fillAmount = Waiters[0] / MaxWaiters[0];

    }


    void PowerActive()
    {

        if (Waiters[1] <= 0 && Input.GetKey(KeyCode.Alpha2))
        {
            Instantiate(Spells[1], transform);
            Waiters[1] = MaxWaiters[1];

        }


        images[1].fillAmount = Waiters[1] / MaxWaiters[1];

    }

    void Krit()
    {
        if (Waiters[2] <= 0 && Input.GetKey(KeyCode.Alpha3)) 
        { 
            isKriting = true;
            playerAttack.PhyDamage = playerAttack.PhyDamage * 2;
            Waiters[2] = MaxWaiters[2];
          



        }

        images[2].fillAmount = Waiters[2] / MaxWaiters[2];
    }


    private void Update()
    {
        if (Waiters[0] >0)
        {
            Waiters[0] -= Time.deltaTime;
        }

        if (Waiters[1] > 0)
        {
            Waiters[1] -= Time.deltaTime;

        }
        if (Waiters[2] > 0)
        {
            Waiters[2] -= Time.deltaTime;

        }


        ShieldActive();
        PowerActive();
        Krit();
    }


   
    
    
    

}
