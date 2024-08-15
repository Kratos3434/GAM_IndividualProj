using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionHealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        slider.value = health;
    }  
    

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
}
