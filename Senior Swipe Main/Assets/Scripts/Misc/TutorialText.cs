using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialText;

    public void ChangeText(string text)
    {
        tutorialText.text = text;
    }
}
