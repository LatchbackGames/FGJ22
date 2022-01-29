using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    private float moveX = 1;
    private float dir = 0;
    private AudioSource asd;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.x == 0 || moveX == movement.x)
            return;
        
        moveX = movement.x;
        animator.SetFloat("Direction", moveX);
        if (animator.GetFloat("Direction") == -1 && animator.GetFloat("Speed") > 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            
        }
        if (animator.GetFloat("Direction") != -1 && animator.GetFloat("Speed") > 0)
        {
            animator.SetFloat("Horizontal", 1);
            
        }
        if(animator.GetFloat("Speed") == 0)
            animator.SetFloat("Horizontal", 0);

        //TODO ANIMATOR FROM TOP DOWN MOVEMENT IN UNIY VIDEO
        if (animator.GetFloat("Speed") != 0)
            GetComponent<AudioSource>().PlayOneShot();
        
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}
