using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    // If the NPC collides with another target with the player's hurtbox, 
    //  increment the NPCs collected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("bullet collision with " + collision.gameObject);
        var targetHealth = collision.gameObject.GetComponent<health>();
        if(targetHealth != null && targetHealth.type == "Player"){
            playerStats playerstats = targetHealth.owner.GetComponent<playerStats>();
            int change = playerstats.changeCoworkers(1);
            // Debug.Log("Player found, " + change + " NPCs total");
            Destroy(gameObject);
        }
    }
}
