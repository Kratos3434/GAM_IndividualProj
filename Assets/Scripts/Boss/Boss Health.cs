using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{

    public float remainingHealth = 2500f;

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI healthText;

    public void SetHealth(float health, float maxHealth)
    {
        remainingHealth = health;
        slider.value = health;
        healthText.text = (int)health + "/" + (int)maxHealth;
    }

    void Update()
    {
        if (remainingHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = slider.maxValue;
        healthText.text = (int)maxHealth + "/" + (int)maxHealth;
    }
}