using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushScript : MonoBehaviour
{
    float lifespan = 3.0f;
    float spawnTime;
    float fadeSpeed = 0.01f;
    float distance = 2f;
    public LayerMask pushMask;
    SpriteRenderer b_sprite;
    GameObject pushObject;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        Destroy(gameObject, lifespan);
        b_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime >= lifespan - 1)
        {
            Color col = b_sprite.color;
            b_sprite.color = new Color(0, 1, 1, col.a - fadeSpeed);
        }
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, pushMask);

        if(hit.collider != null)
        {
            pushObject = hit.collider.gameObject;

            pushObject.GetComponent<Rigidbody2D>().AddForce(2 * Vector2.right, ForceMode2D.Impulse);
        }    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 position =(Vector2) transform.position + Vector2.right;
        Gizmos.DrawLine(transform.position, position * transform.localScale.x * distance);
    }

}
