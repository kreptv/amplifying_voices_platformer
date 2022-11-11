using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int currentHealth;
    public GameObject owner;
    public string type;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;
        type = owner.tag;
    }

    // call this function to add a number to the character's health
    public int changeHealth(int change){
        if (type == "Player"){
            StartCoroutine("Animate");
        }
        currentHealth += change;
        //Debug.Log(owner + " health was changed to " + currentHealth);
        if (currentHealth <= 0){
            //Debug.Log(owner + " is dead");
            defeated();
        }
        return currentHealth;
    }

    IEnumerator Animate(){
      animator.SetBool("IsKnockedBack", true);
      yield return new WaitForSeconds(1);
      animator.SetBool("IsKnockedBack", false);
    }

    // Call this when the owner has no health and dies.
    // Enemies disappear instantly when they die.
    // Player gets a game over screen when they die.
    void defeated(){
        if (type == "Enemy"){
            Destroy(owner);
        }else if(type == "Player"){
            //Debug.Log("GAME OVER");
        }
    }
}
