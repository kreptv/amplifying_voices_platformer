using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameManager gm;
    public GameObject headWrapper;

    float speed = 7.0f;
    Rigidbody2D body;
    public Animator animator;

    public bool grounded;
    public bool facingRight;


    void Awake()
    {

      body = transform.GetComponent<Rigidbody2D>();
      facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


      if (Input.GetAxis("Horizontal") > 0.1 && (transform.position.x < gm.xMax-7)){
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        animator.SetBool("IsRunning", true);
        if (!facingRight){
          facingRight = true;
          transform.localScale = new Vector3(1,1,1);
          headWrapper.transform.localScale = new Vector3(1,1,1);
        }
      } else if (Input.GetAxis("Horizontal") < -0.1 && (transform.position.x > gm.xMin+7)){
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        animator.SetBool("IsRunning", true);
          if (facingRight){
            facingRight = false;
            transform.localScale = new Vector3(-1,1,1);
            headWrapper.transform.localScale = new Vector3(-1,1,1);
          }
      }
      else {
        animator.SetBool("IsRunning", false);
      }

        if (Input.GetKey(KeyCode.Space) && grounded){
            body.velocity = new Vector2(body.velocity.x, speed);
            grounded = false;
            animator.SetBool("IsJumping", true);
        }
    }

    // If player is on the ground, you can jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
            animator.SetBool("IsJumping", false);
    }
}
