﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]private Image[] hearts;
    [SerializeField]private Sprite fullHeart;
    [SerializeField]private Sprite emptyHeart;


    public void UpdateHealth(float health, float numberOfHearts)
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
