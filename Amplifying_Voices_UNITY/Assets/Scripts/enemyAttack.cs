using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    float attackCooldown = 5.0f;
    float attackFinish;
    float attackRange = 8.0f;
    float projectileSpeed = 10.0f;

    public GameObject player;
    public GameObject[] objectsSpawning;
    public GameObject projectileTransform;

    void Start(){
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // find where the player is and point to them
        Vector3 pos = transform.position;
        Vector3 dir = (player.transform.position - pos).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // if the player is close enough and the attack is ready, fire a projectile at the player
        float playerDistance = (player.transform.position - pos).magnitude;
        if (playerDistance <= attackRange && Time.time > attackFinish){
            //Debug.Log("an enemy attacked!");
            attackFinish = Time.time + attackCooldown;

            int objectIndex = Random.Range(0, objectsSpawning.Length - 1);
            GameObject bullet = Instantiate(objectsSpawning[objectIndex], projectileTransform.transform.position, Quaternion.Euler( 0, 0, angle));
            bullet.GetComponent<Rigidbody2D>().AddForce(projectileSpeed * dir, ForceMode2D.Impulse);
            bulletScript bulletscript = bullet.GetComponent<bulletScript>();
            bulletscript.owner = transform.parent.tag;
        }
    }
}
