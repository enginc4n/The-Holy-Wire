using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public AudioSource menuFx;
    public AudioClip ClickFx;

    public void gameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
        Cursor.visible = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
    }

    public void ClickSound()
    {
        menuFx.PlayOneShot(ClickFx);
    }
}
