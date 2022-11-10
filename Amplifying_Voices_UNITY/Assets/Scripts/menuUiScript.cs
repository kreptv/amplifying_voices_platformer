using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuUiScript : MonoBehaviour
{
    public void playBtn()
    {

        SceneManager.LoadScene(2);
    }

    public void quit()
    {
        Application.Quit();
    }
    
}
