using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    
public static bool GameIsPause = false;
public GameObject pauseMenuUI;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    //Time.timeScale is the timeScale that the game is running on (meaning 0f=paused and 1f=running normally - this can be used for slowmotion effects)
    public void Resume()   //Method to Resume game
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()    //Method to Pause game
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game");
        Application.Quit();
    }
}
