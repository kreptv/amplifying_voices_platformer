using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponterController : MonoBehaviour
{
    float clickCooldown = 3.0f;
    float clickFinish;
    public GameObject player;
    float Speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0) && Time.time > clickFinish){
            Debug.Log("click 1");
            clickFinish = Time.time + clickCooldown;
            Vector3 norm = pos.normalized;
            //player.transform.position = norm;
            //player.GetComponent<Rigidbody2D>().AddForce(dir.normalized * Speed);
        }
    }

    private void FixedUpdate()
    {

    }
}
