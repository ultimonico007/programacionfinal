using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontroler : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
    }

    public void Startgame()
    {
        SceneManager.LoadScene("principal");
    }

    
    public void quitgame()
    {
        Application.Quit();
    }
}
