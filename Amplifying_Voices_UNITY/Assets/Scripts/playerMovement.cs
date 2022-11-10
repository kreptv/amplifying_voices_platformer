using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

public class playerMovement : MonoBehaviour
{
    public GameManager gm;
    public GameObject headWrapper;
    public CubismModel playerModel;

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

    void LateUpdate(){

      Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
      Vector3 dir = (Input.mousePosition - pos).normalized;
      /****** FOR PLAYER HEAD TRACKING ******/
      /*var x = playerModel.Parameters[8];
      var y = playerModel.Parameters[9];

      var range1 = 1 - (-1);
      var range2 = 30 - (-30);
      var range3 = 0 - (-30);

      if (facingRight){
        x.Value = (((dir.x - (-1)) * range3) / range1) -30;
        y.Value = (((dir.y - (-1)) * range2) / range1) -30;
      } else {
        x.Value = -((((dir.x - (-1)) * range3) / range1) -0);
        y.Value = (((dir.y - (-1)) * range2) / range1) -30;
      }*/

      //Debug.Log(x.Value);
      //Debug.Log(y.Value);

      /***********/

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (gm.bindMovement){return;}


      if (Input.GetAxis("Horizontal") > 0.1 /*&& (transform.position.x < gm.xMax-7)*/){
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        animator.SetBool("IsRunning", true);
        if (!facingRight){
          facingRight = true;
          transform.localScale = new Vector3(1,1,1);
          headWrapper.transform.localScale = new Vector3(1,1,1);
        }
      } else if (Input.GetAxis("Horizontal") < -0.1 /*&& (transform.position.x > gm.xMin+7)*/){
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
