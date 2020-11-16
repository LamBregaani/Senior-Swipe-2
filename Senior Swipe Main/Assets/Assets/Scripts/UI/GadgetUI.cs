using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GadgetUI : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;

    [SerializeField] private GameObject primaryUI;

    [SerializeField] private GameObject secondaryUI;

    private void OnEnable()
    {
        mainUI.SetActive(true);
    }

    private void OnDisable()
    {
        mainUI.SetActive(false);
    }
}
