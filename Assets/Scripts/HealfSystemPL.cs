using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealfSystemPL : MonoBehaviour
{
    public Image image;

    public float healf;
    public float maxHeafl;

    float fill = 1f;
    void Start()
    {
        healf = maxHeafl;
    }

    void Update()
    {
        image.fillAmount = healf/maxHeafl;
    }




    public void TakeDamage(float damage)
    {

        healf -= damage;
    }
}
