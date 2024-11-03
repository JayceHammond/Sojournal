using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float jumpSpeed;
    public float fallTimer;
    public bool isGrounded = false;
    public int health;
    public int atkDMG;
    private Rigidbody2D rb;
    private Animator animator;
    public BoxCollider2D grndCollider;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Movement(moveHorizontal);
        Jump(isGrounded);
        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                StartCoroutine(NoCollisionCoroutine());             
            }
        }

    }


    void Movement(float moveHorizontal){
        if(moveHorizontal > 0){
            GetComponent<SpriteRenderer>().flipX = false;
            animator.Play("RunAnim");
            rb.velocity = new Vector2(moveHorizontal*speed, rb.velocity.y);
            
        }else if(moveHorizontal < 0){
            GetComponent<SpriteRenderer>().flipX = true;
            animator.Play("RunAnim");
            rb.velocity = new Vector2(moveHorizontal*speed, rb.velocity.y);
            
        }
        else{
            animator.Play("IdleAnim");
        }

    }

    void Jump(bool isGrounded){
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true){
            //animator.Play("JumpAnim"); SCRAPPED
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight * jumpSpeed);
        }
    }

void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }


IEnumerator NoCollisionCoroutine(){
    grndCollider.enabled = false;
    yield return new WaitForSeconds(fallTimer);
    grndCollider.enabled = true;
}

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
