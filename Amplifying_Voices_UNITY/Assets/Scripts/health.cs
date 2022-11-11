using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    public int currentHealth;
    public GameObject owner;
    public string type;
    public Animator animator;
    public Image fullHealthImg;
    public Image halfHealthImg;
    public Image LastHealthImg;
    public GameObject gameOver;
    public GameObject win;
    public bool isGlas;
    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;
        type = owner.tag;
    }

    private void Update()
    {
        
    }

    // call this function to add a number to the character's health
    public int changeHealth(int change){
        
        currentHealth += change;
        if (type == "Player"){

            StartCoroutine("Animate");
            
            if (currentHealth == 2)
            {
                fullHealthImg.sprite = halfHealthImg.sprite;
            }
            else if (currentHealth == 1)
            {
                fullHealthImg.sprite = LastHealthImg.sprite;
            }
            else
            {
                fullHealthImg.sprite = fullHealthImg.sprite;
            }



        }


        //Debug.Log(owner + " health was changed to " + currentHealth);
        if (currentHealth <= 0){
            //Debug.Log(owner + " is dead");
            //add game over screen
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
        if (isGlas && type == "Enemy")
        {
            win.SetActive(true);
            
        
        }else if (type == "Enemy"){
            Destroy(owner);
        }else if(type == "Player"){

            gameOver.SetActive(true);
        }
    }
}
