using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

public class ObjectTrackingPlayerScript :  MonoBehaviour
{
    public CubismModel model;
    public BoxCollider2D playerInRange;
      public float xMin, xMax, yMin, yMax;
    public GameObject player;

    private float px = 0;
    private float py = 0;


    public bool camon;

    private void Start()
    {
      player = GameObject.Find("Player");
      camon = false;

      xMin = playerInRange.bounds.min.x;
      xMax = playerInRange.bounds.max.x;
      yMin = playerInRange.bounds.min.y;
      yMax = playerInRange.bounds.max.y;

    }

    private void LateUpdate()
    {
      var x = model.Parameters[0];
      var y = model.Parameters[1];
      var eyeOpen = model.Parameters[2];

      px = player.transform.position.x;
      py = player.transform.position.y;
      var range1 = xMax - xMin;
      var range2 = 30 - (-30);
      px = (((px - xMin) * range2) / range1) -30;

      range1 = yMax - yMin;
      range2 = 30 - (-30);
      py = (((py - yMin) * range2) / range1) -30;


      x.Value = px;
      y.Value = py;

      if (camon == true){

        eyeOpen.Value = 1f;
      }

      else {
        eyeOpen.Value = 0f;
        x.Value = px;
        y.Value = py;


      }




    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            camon = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            camon = false;
    }


}
