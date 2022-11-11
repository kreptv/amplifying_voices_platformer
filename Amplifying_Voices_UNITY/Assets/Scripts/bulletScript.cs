using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    float lifespan = 3.0f;
    float spawnTime;
    float fadeSpeed = 0.01f;
    SpriteRenderer b_sprite;

    public string owner = "";
    int bulletDamage = -2;

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
        if (Time.time - spawnTime >= lifespan - 1){
            Color col = b_sprite.color;
            b_sprite.color = new Color(1, 1, 1, col.a - fadeSpeed);
        }
    }

    // If the bullet collides with another target with a health script, deal damage.
    // Note that the bullet ignores targets with the same tag as the owner.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("bullet collision with " + collision.gameObject);
        var targetHealth = collision.gameObject.GetComponent<health>();
        if(targetHealth != null && targetHealth.type != owner){
            // Debug.Log(targetHealth.type + " is not " + owner + ", valid target");
            targetHealth.changeHealth(bulletDamage);
            Destroy(gameObject);
        }
    }
}
