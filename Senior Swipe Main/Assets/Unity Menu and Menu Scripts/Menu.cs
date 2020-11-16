using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject howToPlay;

    private int currentMenu;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        currentMenu = 1;
    }

    public void PlayGame(string LevelSelect)
    {
        SceneManager.LoadScene("Level One");
    }

    public void HowToPlay()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);

        currentMenu = 2;
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);

        currentMenu = 3;
    }

    public void GoBack()
    {
        if (currentMenu == 2)
        {
            howToPlay.SetActive(false);
            mainMenu.SetActive(true);

            currentMenu = 1;
        }

        if (currentMenu == 3)
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);

            currentMenu = 1;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
