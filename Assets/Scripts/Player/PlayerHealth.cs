using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        slider.value = health;
        if (health < 200f)
        {
            fill.color = Color.red;
        }
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
}
