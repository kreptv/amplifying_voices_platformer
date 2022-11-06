using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public BoxCollider2D mapBounds;
  public float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
      xMin = mapBounds.bounds.min.x;
      xMax = mapBounds.bounds.max.x;
      yMin = mapBounds.bounds.min.y;
      yMax = mapBounds.bounds.max.y;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
