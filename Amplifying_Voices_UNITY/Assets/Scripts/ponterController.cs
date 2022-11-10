using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ponterController : MonoBehaviour
{
    float clickCooldown = 3.0f;
    float clickFinish;
    float projectileSpeed = 10.0f;

    float pushForce = 7.0f;

    public GameObject player;
    public GameObject[] objectsSpawning;
    public GameObject projectileTransform;

    void Start(){
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // find where the mouse is and point to them
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - pos).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // if the player left clicks and their attack is ready, fire a projectile at the mouse
        if (Input.GetMouseButtonDown(0) && Time.time > clickFinish){
            // Debug.Log("click 1: FIRE");
            clickFinish = Time.time + clickCooldown;
            
            int objectIndex = Random.Range(0, objectsSpawning.Length - 1);
            GameObject bullet = Instantiate(objectsSpawning[objectIndex], projectileTransform.transform.position, Quaternion.Euler( 0, 0, angle ));
            bullet.GetComponent<Rigidbody2D>().AddForce(projectileSpeed * dir, ForceMode2D.Impulse);
            bulletScript bulletscript = bullet.GetComponent<bulletScript>();
            bulletscript.owner = transform.parent.tag;
        }

        // if the player right clicks and the ability is ready, push the player away from the mouse
        if(Input.GetMouseButtonDown(1) && Time.time > clickFinish)
        {
            // Debug.Log("click 2 PUSH");
            clickFinish = Time.time + clickCooldown;

            // int objectIndex = Random.Range(1, objectsSpawning.Length - 1);
            // GameObject push = Instantiate(objectsSpawning[1], projectileTransform.transform.position, Quaternion.Euler(0, 0, angle);
            player.GetComponent<Rigidbody2D>().AddForce(pushForce * -dir, ForceMode2D.Impulse);
        }
    }
}
