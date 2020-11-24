using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseGameSingleton : MonoBehaviour
{
    public static PauseGameSingleton instance { get; private set; }

    [System.Serializable]
    public class GamePausedEvent : UnityEvent { }

    public GamePausedEvent onGamePaused;


    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    

    public void Pause()
    {
        onGamePaused?.Invoke();
        Time.timeScale = 0;

    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
