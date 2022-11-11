using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;
using Live2D.Cubism.Rendering;

public class ElevatorScript : MonoBehaviour
{
    public int floorNum;
    public GameObject player;
    public GameManager gm;
    public ElevatorsManager em;

    [Space]
    [Header("You shouldnt need to edit these:")]
    public Animator animator;
    public CubismModel model;
    public BoxCollider2D playerInRange;
    public CubismDrawable door1; public CubismDrawable door2;
    public CubismDrawable doorframe;

    void Start (){
      player = GameObject.Find("/Player");
      gm = GameObject.Find("/Main Camera").GetComponent<GameManager>();
    }

    public void setDoorsForeground(){
      door1.GetComponent<CubismRenderer>().LocalSortingOrder = 4;
      door2.GetComponent<CubismRenderer>().LocalSortingOrder = 4;
      doorframe.GetComponent<CubismRenderer>().LocalSortingOrder = 4;
    }

    public void setDoorsBackground(){
      door1.GetComponent<CubismRenderer>().LocalSortingOrder = 0;
      door2.GetComponent<CubismRenderer>().LocalSortingOrder = 0;
      doorframe.GetComponent<CubismRenderer>().LocalSortingOrder = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player"){
          if (em.canBeUsed){
            em.elevatorOn = true;
          }
        }
    }
}
