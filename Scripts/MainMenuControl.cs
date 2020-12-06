using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject credits;
    public GameObject howToPlayMenu;
    public GameObject mainMenu;


    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit button pressed");
    }

    public void creditMenu()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void howToPlay()
    {
        howToPlayMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void returnToMainMenu()
    {
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
        credits.SetActive(false);
    }
}
