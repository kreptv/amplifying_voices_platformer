using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuUiScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseUi;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void playBtn()
    {

        SceneManager.LoadScene(3);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("UITest");
    }
    
}
