using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class settingMenuItem : MonoBehaviour
{
    [HideInInspector] public Image img;
    [HideInInspector] public Transform trans;
    
    // Start is called before the first frame update

    private void Awake()
    {
        img = GetComponent<Image>();
        trans = transform;
        OnEnable(false);
    }

    public void OnEnable(bool isEnable)
    {
        gameObject.SetActive(isEnable);
    }

}
