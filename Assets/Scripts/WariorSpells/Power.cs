using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    public float Endurance;
    public float Speed;

    public float Wait;


    HealfSystemPL systemPL;

    PlayerMove playerMove;

    float oldEnd;
    float oldspeed;


    SpriteRenderer renderere;

    private void Start()
    {
        systemPL = GetComponentInParent<HealfSystemPL>();
        playerMove = GetComponentInParent<PlayerMove>();
        renderere = GetComponentInParent<SpriteRenderer>();


        renderere.color = Color.red;

        oldEnd = systemPL.maxendurance;
        oldspeed = playerMove.speed;
        systemPL.isRage = true;
        systemPL.maxendurance = Endurance;
        systemPL.endurance = systemPL.maxendurance;

        playerMove.speed = Speed;


    }

    void Update()
    {
        Wait -= Time.deltaTime;
       

        if (Wait<=0)
        {
            systemPL.maxendurance = oldEnd;
            playerMove.speed = oldspeed;
            systemPL.isRage = false;
            renderere.color = Color.white;

            Destroy(gameObject);
        }
    }
}
