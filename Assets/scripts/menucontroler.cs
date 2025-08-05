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

    public void nivel1()
    {
        SceneManager.LoadScene("FACIL");
    }
    public void nivel2()
    {
        SceneManager.LoadScene("MEDIO");
    }
    public void nivel3()
    {
        SceneManager.LoadScene("DIFICIL");
    }
    public void Startgame()
    {
        SceneManager.LoadScene("tutorial");
    }


    public void quitgame()
    {
        Application.Quit();
    }
}
