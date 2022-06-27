using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_base : MonoBehaviour
{
  public  enum State
    {
        idle,
        walk,
        attack,
        stagger
    }


    

    public float healf;
    public float speed;
    public float damage;

    private Transform target;

    public float attackRadius;
    public float ChaseRadius;

    public Transform Home;

    Rigidbody2D rb;
   public State Curretstate;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        CheckDis();
    }


    void CheckDis()
    {
        if (Vector3.Distance(target.position, transform.position) <= ChaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (Curretstate ==State.idle|| Curretstate == State.walk && Curretstate != State.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                rb.MovePosition(temp);
                ChangeState(State.walk);
            }
           

        }
    }

    private void ChangeState(State newState)
    {
        if (Curretstate!=newState)
        {
            Curretstate = newState;
        }

    }

}
