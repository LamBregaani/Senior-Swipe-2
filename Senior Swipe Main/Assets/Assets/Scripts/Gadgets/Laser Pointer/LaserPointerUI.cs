using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserPointerUI : MonoBehaviour
{
    [SerializeField] Image energyBar;


    public void UpdateUI(float currentEnergy, float maxEnergy)
    {
        energyBar.fillAmount = currentEnergy / maxEnergy;
    }
}
