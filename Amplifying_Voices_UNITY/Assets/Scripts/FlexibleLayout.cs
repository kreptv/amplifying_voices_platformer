using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleLayout : MonoBehaviour
{
    public GameObject volumeOption;
    public GameObject senOption;
    public void addOption()
    {
       
       

        Instantiate(volumeOption, gameObject.transform);
        Instantiate(senOption, gameObject.transform);
    }
}
