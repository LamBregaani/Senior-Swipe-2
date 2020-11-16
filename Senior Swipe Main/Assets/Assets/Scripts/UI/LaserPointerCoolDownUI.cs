using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserPointerCoolDownUI : MonoBehaviour
{
    [SerializeField] private Image uIElement;

    private bool coolDown;

    public void StartCoolDownUI(float coolDownTime)
    {

        if (!coolDown)
        {
            Debug.Log("Started!");
            coolDown = true;

            StartCoroutine(Reload(coolDownTime));
        }

        
    }

    public void StopCoolDownUI()
    {
        StopAllCoroutines();
    }

    private IEnumerator Reload(float coolDownTime)
    {
        uIElement.fillAmount = 0;
        for (float i = 0; i < coolDownTime; i += Time.deltaTime)
        {
            float fillPercentage = i / coolDownTime;

            uIElement.fillAmount = fillPercentage;
            yield return new WaitForEndOfFrame();
        }
        uIElement.fillAmount = 1;
        yield return new WaitForSeconds(0.3f);
        uIElement.fillAmount = 0;
        coolDown = false;

    }
}
