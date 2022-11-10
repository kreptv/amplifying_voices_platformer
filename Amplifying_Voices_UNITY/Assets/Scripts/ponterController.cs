using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ponterController : MonoBehaviour
{
    float clickCooldown = 3.0f;
    float clickFinish;
    float projectileSpeed = 10.0f;

    public GameObject player;
    public GameObject[] objectsSpawning;
    public GameObject projectileTransform;

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
            Debug.Log("click 2 PUSH");
            clickFinish = Time.time + clickCooldown;

            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 direction = target - myPos;

            direction.Normalize();
            int objectIndex = Random.Range(1, objectsSpawning.Length - 1);
            GameObject push = Instantiate(objectsSpawning[1], projectileTransform.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
            push.GetComponent<Rigidbody2D>().AddForce(10 * dir, ForceMode2D.Impulse);
        }
    }
}
