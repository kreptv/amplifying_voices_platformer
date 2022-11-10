using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

public class BusinessManEnemyScript : MonoBehaviour
{

    ObjectTrackingPlayerScript os;
    public CubismModel model;
    public bool facingRight;
    public GameObject headWrapper;

    Vector2 location;


    // Start is called before the first frame update
    void Start()
    {
      os = this.GetComponent<ObjectTrackingPlayerScript>();
      facingRight = false;

      InvokeRepeating("Frustrated", 10.0f, 10.0f);
      InvokeRepeating("Clear", 10.5f, 10f);

      location = this.transform.position;



    }

    void Frustrated(){
      model.GetComponent<Animator>().SetBool("IsFrustrated", true);
    }
    void Clear(){
      model.GetComponent<Animator>().SetBool("IsFrustrated", false);
    }

    // Update is called once per frame
    void FixedUpdate(){

      if (os.player.transform.position.x > location.x){
        facingRight = true;
        transform.localScale = new Vector3(1,1,1);
        headWrapper.transform.localScale = new Vector3(1,1,1);
      }
      if (os.player.transform.position.x < location.x){
        facingRight = false;
        transform.localScale = new Vector3(-1,1,1);
        headWrapper.transform.localScale = new Vector3(-1,1,1);
      }






    }


}
