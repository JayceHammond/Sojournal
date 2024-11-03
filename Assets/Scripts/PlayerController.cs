using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool isGrounded;
    public int health;
    public int atkDMG;
    private Rigidbody2D rb;
    private Animator animator;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal > 0){
            GetComponent<SpriteRenderer>().flipX = false;
            Movement(moveHorizontal);
        }else if(moveHorizontal < 0){
            GetComponent<SpriteRenderer>().flipX = true;
            Movement(moveHorizontal);
        }
        else{
            animator.Play("IdleAnim");
        }
        

    }


    void Movement(float moveHorizontal){
        animator.Play("RunAnim");
        rb.velocity = new Vector2(moveHorizontal*speed, rb.velocity.y);

    }

    void FlipPlayer(float dir){

    }
}
