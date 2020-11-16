using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GadgetUI : MonoBehaviour
{
    [SerializeField] private bool toggleableUIs;

    [SerializeField] private GameObject mainUI;

    [SerializeField] private GameObject primaryUI;

    [SerializeField] private GameObject secondaryUI;

    private GameObject currentUI;

    private bool isPrimary;

    private void Start()
    {
        if (!toggleableUIs)
        {
            ChangeToMain();
        }
        else
        {
            ChangeToPrimary();
            isPrimary = true;
        }
    }

    private void OnEnable()
    {
        currentUI.SetActive(true);
    }

    private void OnDisable()
    {
        currentUI.SetActive(false);
    }

    public void ChangeToMain()
    {
        if(currentUI != mainUI)
        {
            currentUI?.SetActive(false);
            currentUI = mainUI;
            currentUI?.SetActive(true);
        }

    }

    public void ChangeToPrimary()
    {
        if(currentUI != primaryUI)
        {
            currentUI?.SetActive(false);
            currentUI = primaryUI;
            currentUI?.SetActive(true);
        }

    }

    public void ChangeToSecondary()
    {
        if(currentUI != secondaryUI)
        {
            currentUI?.SetActive(false);
            currentUI = secondaryUI;
            currentUI?.SetActive(true);
        }

    }

    public void ToggleUIs()
    {
        currentUI?.SetActive(false);
        isPrimary = !isPrimary;

        if(isPrimary)
        {
            currentUI = primaryUI;
        }
        else
        {
            currentUI = secondaryUI;
        }

        currentUI?.SetActive(true);
    }

    
}
