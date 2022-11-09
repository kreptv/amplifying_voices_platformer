using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;
using Live2D.Cubism.Rendering;

public class ElevatorsManager : MonoBehaviour
{

    public GameObject player;
    public GameManager gm;

    public int currentFloor;

    public AudioClip ElevatorDing;

    public bool elevatorOn; bool movingPlayer; public bool canBeUsed;

    public GameObject elevatorEncapsulator;
    public GameObject[] floors;

    [HideInInspector]
    public GameObject[] elevators;


    // Start is called before the first frame update
    void Start()
    {
      elevators = new GameObject[elevatorEncapsulator.transform.childCount];

      for (int i = 0; i < elevatorEncapsulator.transform.childCount; i++){
        elevators[i] = elevatorEncapsulator.transform.GetChild(i).gameObject;
        Debug.Log("Registered elevator " + i + ".");
      }
      if (floors.Length != elevators.Length){
        Debug.Log("There should be one elevator on each floor");
      }

      currentFloor = 0;

      for (int i = 1; i < floors.Length; i++){
          floors[i].SetActive(false);
      }

      elevatorOn = false; movingPlayer = false; canBeUsed = false;
    }

    private void Update(){
      if (!canBeUsed){
        if (gm.progress == currentFloor+1 && !(gm.progress >= floors.Length)){
          elevatorEncapsulator.GetComponent<AudioSource>().PlayOneShot(ElevatorDing);
          canBeUsed = true;
        }
      }
    }

    private void LateUpdate()
    {
      if (elevatorOn && !player.transform.GetChild(0).GetComponent<Animator>().GetBool("IsJumping")
      && !player.transform.GetChild(0).GetComponent<Animator>().GetBool("IsRunning")
      && !player.transform.GetChild(0).GetComponent<Animator>().GetBool("IsKnockedBack") &&!gm.bindMovement){
        if (Input.GetKeyDown(KeyCode.UpArrow)){
          elevatorOn = true; gm.bindMovement = true;
          elevators[currentFloor].GetComponent<Animator>().SetBool("IsOpeningUp", true);
          StartCoroutine(DoorsOpen());
        }
      }
      if (movingPlayer){
        floors[currentFloor].SetActive(true);
        float step = 2 * Time.deltaTime;
        player.transform.position = Vector2.MoveTowards(player.transform.position, elevators[currentFloor].transform.position - new Vector3(0, 1f, 0), step);
        if (player.transform.position == elevators[currentFloor].transform.position - new Vector3(0, 1f, 0)) {
          elevators[currentFloor].GetComponent<Animator>().SetBool("IsOpeningUp", true);
          floors[currentFloor-1].SetActive(false);
          StartCoroutine(DoorsOpen2());
        }
      }
    }

    public IEnumerator DoorsOpen(){
    yield return new WaitForSeconds(2f);
    elevators[currentFloor].GetComponent<Animator>().SetBool("IsOpeningUp", false);
    elevators[currentFloor].GetComponent<ElevatorScript>().setDoorsForeground();
    elevators[currentFloor+1].GetComponent<ElevatorScript>().setDoorsForeground();
    yield return new WaitForSeconds(3f);
    player.SetActive(false); movingPlayer = true;
    currentFloor = gm.progress;
    }

    public IEnumerator DoorsOpen2(){
      player.SetActive(true); movingPlayer = false;
      yield return new WaitForSeconds(2f);
      elevators[currentFloor].GetComponent<Animator>().SetBool("IsOpeningUp", false);
      elevators[currentFloor-1].GetComponent<ElevatorScript>().setDoorsBackground();
      elevators[currentFloor].GetComponent<ElevatorScript>().setDoorsBackground();
      elevatorOn = false; gm.bindMovement = false;
      canBeUsed = false;

    }










}
