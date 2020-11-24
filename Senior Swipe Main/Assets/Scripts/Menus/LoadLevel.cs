using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LevelToLoad(string _levelName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_levelName);
    }
}
