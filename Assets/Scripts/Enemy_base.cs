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



    public int EXP;
    public float healf;
    public float speed;
    public float damage;

    private Transform target;

    public float attackRadius;
    public float ChaseRadius;

    public Transform Home;

    Rigidbody2D rb;
   public State Curretstate;


    KnockBack knockBack;


    Animator animator;


   public bool attacking;

    public GameObject Pl;



    public bool IfFires;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        knockBack = FindObjectOfType<KnockBack>();


        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        CheckDis();


        if (healf<=0)
        {
            DEs();
        }

       
    }


    void CheckDis()
    {
        if (Vector3.Distance(target.position, transform.position) <= ChaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if ( Curretstate != State.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                rb.MovePosition(temp);
                ChangeState(State.walk);
                animator.SetBool("IsWakeUp", true);

                changeAnimWalk(temp - transform.position);
                animator.SetBool("Attack", false);

            }


        }

        else if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            ChangeState(State.attack);
            animator.SetBool("Attack", true);

        }
        else if(Vector3.Distance(target.position, transform.position) > ChaseRadius)
        {
            ChangeState(State.idle);
            animator.SetBool("IsWakeUp", false);
            animator.SetBool("Attack", false);


        }
    }

    private void ChangeState(State newState)
    {
        if (Curretstate!=newState)
        {
            Curretstate = newState;
        }

    }


    void setVector(Vector2 set)
    {

        animator.SetFloat("moveX", set.x);
        animator.SetFloat("moveY", set.y);


    }

    void changeAnimWalk(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                setVector(Vector2.right);
            }
            else if (direction.x < 0)
            {
                setVector(Vector2.left);

            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                setVector(Vector2.up);

            }
            else if (direction.y < 0)
            {
                setVector(Vector2.down);

            }
        }
        
        

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Curretstate == State.attack && attacking)
        {
            HealfSystemPL healfSystemPL = collision.GetComponent<HealfSystemPL>();
            healfSystemPL.TakeDamage(damage);
        }

        else if (collision.CompareTag("Shield" )&&Curretstate == State.attack && attacking)
        {
            Shield shield = collision.GetComponent<Shield>();
            shield.TakeDamge(damage);
        }
    }

    public void DEs()
    {
        Destroy(gameObject);

        //if (Pl.CompareTag("Player"))
        //{
        //    PlayerVaribies playerVaribies = Pl.GetComponent<PlayerVaribies>();
        //    playerVaribies.exp += EXP;
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HitPl"))
        {
            PlayerMove player = collision.GetComponentInParent<PlayerMove>();
            PlayerAttack playerAttack = collision.GetComponentInParent<PlayerAttack>();
            if (player.cuuretState == PlayerMove.State.fight)
            {
                healf -= playerAttack.PhyDamage;
            }
           

        }
    }
}
