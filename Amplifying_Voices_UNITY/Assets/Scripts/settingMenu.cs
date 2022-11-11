using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class settingMenu : MonoBehaviour
{
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    public Button mainButton;
    settingMenuItem[] menuItems;
    bool isExpanded = false;

    Vector2 mainButtonPosition;
    int itemsCount;
    // Start is called before the first frame update
    void Start()
    {
        itemsCount = transform.childCount - 1;
        menuItems = new settingMenuItem[itemsCount];
        for (int i = 0; i< itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<settingMenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.transform.position;

        ResetPosition();
    }

    void ResetPosition()
    {
        for(int i = 0; i< itemsCount; i++ )
        {
           menuItems[i].trans.position = mainButtonPosition;
           menuItems[i].OnEnable(false);
           
        }
    }

    public void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if(isExpanded)
        {
            for(int i=0; i< itemsCount; i++)
            {
                menuItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
                menuItems[i].OnEnable(true);
                
            }
            
        }
        else
        {

            ResetPosition();
        }
    }

    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
