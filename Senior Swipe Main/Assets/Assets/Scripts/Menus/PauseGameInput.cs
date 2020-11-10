using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameInput : MonoBehaviour
{
    public void PauseTheGame()
    {
        PauseGameSingleton.instance.Pause();
    }

    public void ResumeTheGame()
    {

    }
}
