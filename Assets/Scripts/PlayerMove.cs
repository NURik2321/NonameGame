using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   public enum State
    {

        walk,
        fight,
        interact,
    }

    public State cuuretState; 
    Rigidbody2D rb;

   private Vector3 movement;


    public float speed;


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cuuretState = State.walk;
    }
    private void Update()
    {
        movement = Vector3.zero;


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



        if (Input.GetButtonDown("attack") && cuuretState!= State.fight)
        {
            StartCoroutine(AttackCo());
        }

       else if (cuuretState == State.walk )
        {
            AnimationplayWalk_AndWalk();
        }

    }
    
    
    

    void AnimationplayWalk_AndWalk()
    {
        if (movement != Vector3.zero)
        {
            rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            animator.SetBool("move", true);
        }

        else
        {
            animator.SetBool("move", false);
        }
       
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attack", true);
        cuuretState = State.fight;
        yield return null;
        animator.SetBool("attack", false);
        yield return new WaitForSeconds(.33f);
        cuuretState = State.walk;


    }
}
