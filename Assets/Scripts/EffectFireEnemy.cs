using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFireEnemy : MonoBehaviour
{
    Enemy_base enemy_Base;

    public float wait;


    private void Start()
    {
        enemy_Base = GetComponentInParent<Enemy_base>();
    }
    void Update()
    {
        wait -= Time.deltaTime;
        
        enemy_Base.healf -= (float)0.01;

        if (wait <=0)
        {
            enemy_Base.IfFires = false;
            Destroy(gameObject);
        }
    }

   
}
