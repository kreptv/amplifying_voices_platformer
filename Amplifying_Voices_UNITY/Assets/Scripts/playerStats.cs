using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    int currentCoworkers = 0;
    int currentLevel = 0;
    public GameManager gm;

    // Change the values so that the number in a spot is the number of
    // npcs required to unlock the elevator on that floor.
    int[] levelRequirements = new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};

    void Start(){
        gm = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    // call this function to add a number to the coworkers(npcs) found by the player
    public int changeCoworkers(int change){
        currentCoworkers += change;
        Debug.Log("NPCs = " + currentCoworkers);
        if (currentCoworkers >= levelRequirements[currentLevel]){
            currentLevel += 1;
            if (currentLevel >= levelRequirements.Length){
                Debug.Log("CurrentLevel is outside of bounds");
                currentLevel = levelRequirements.Length - 1;
                return -1;
            }
            gm.progress = currentLevel;
            Debug.Log(currentCoworkers + " collected, moving to level " + currentLevel);
        }
        return currentCoworkers;
    }
}
