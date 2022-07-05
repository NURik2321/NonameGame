using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float wait;

    public float healf;

    public HealfSystemPL systemPL;

    private void Update()
    {
        wait -= Time.deltaTime;
        if (wait <=0 || healf <=0)
        {
            systemPL.Shield = false;
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        systemPL = FindObjectOfType<HealfSystemPL>();
        systemPL.Shield = true;
    }
    public void TakeDamge(float damage)
    {
        healf -= damage;
    }
}
