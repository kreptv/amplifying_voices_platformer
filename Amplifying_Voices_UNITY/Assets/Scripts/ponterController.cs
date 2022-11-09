using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ponterController : MonoBehaviour
{
    float clickCooldown = 3.0f;
    float clickFinish;
    public GameObject player;

    public GameObject[] objectsSpawning;
    public GameObject soundParent;
    public GameObject projectileTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




      Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
      Vector3 dir = (Input.mousePosition - pos).normalized;
      float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

      //Debug.Log(dir);

        if (Input.GetMouseButtonDown(0) && Time.time > clickFinish){
            // Debug.Log("click 1");
            clickFinish = Time.time + clickCooldown;
            // ****** New stuff; gets rotation
            Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
            Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
            Vector2 direction = target - myPos;
            // *******
            direction.Normalize();
            //player.transform.position = norm;
            //player.GetComponent<Rigidbody2D>().AddForce(dir.normalized * Speed);
            int objectIndex = Random.Range(0, objectsSpawning.Length - 1);
            // Debug.Log(transform.position);
            GameObject bullet = Instantiate(objectsSpawning[objectIndex], projectileTransform.transform.position, Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg ));//, soundParent.transform);
            //bullet.transform.forward = dir;
            //bullet.transform.rotation = Quaternion.LookRotation(dir);

            bullet.GetComponent<Rigidbody2D>().AddForce(10 * dir, ForceMode2D.Impulse);
            bulletScript bulletscript = bullet.GetComponent<bulletScript>();
            bulletscript.owner = transform.parent.tag;
        }
    }

    private void FixedUpdate()
    {

    }
}
