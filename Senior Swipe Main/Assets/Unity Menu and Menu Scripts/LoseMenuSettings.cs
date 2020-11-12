using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenuSettings : MonoBehaviour
{
    public static bool hasWon;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Win")
        {
            hasWon = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry(string LevelSelect)
    {
        SceneManager.LoadScene("Level One");
    }

    public void MainMenu(string MainMenu)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
