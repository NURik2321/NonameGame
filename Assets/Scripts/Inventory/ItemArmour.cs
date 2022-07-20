using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemArmour : MonoBehaviour
{





    ItemEqpent itemEqpent;


    public RuntimeAnimatorController animatorController;
    public RuntimeAnimatorController oldanimatorController;



    public string names;



   public PlayerMove move;


    public GameObject Fire;


    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        itemEqpent = GetComponent<ItemEqpent>();
        move = FindObjectOfType<PlayerMove>();
        flag = true;
      }
    

    // Update is called once per frame
    void Update()
    {

        if (itemEqpent.isEqpet)
        {
            oldanimatorController = move.animatorController;
            move.animator.runtimeAnimatorController = animatorController;

            if (flag)
            {
                Instantiate(Fire, move.gameObject.transform);
                flag = false;

            }



        }


        else
        {
            move.animator.runtimeAnimatorController = oldanimatorController;

            fireSystem fireSystem = FindObjectOfType<fireSystem>();

            if (fireSystem !=null && !flag)
            {
                Destroy(fireSystem.gameObject);
            }
        }

    }
}
