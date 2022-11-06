using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    float lifespan = 3.0f;
    float spawnTime;
    float fadeSpeed = 0.01f;
    SpriteRenderer b_sprite;

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
}
