using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProtectorHealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI healthText;

    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health;
        healthText.text = (int)health + "/" + (int)maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = slider.maxValue;
        healthText.text = (int)maxHealth + "/" + (int)maxHealth;
    } 

}
