using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI health;
    // Start is called before the first frame update
    
    public void setHealthText(float currentHealth, float maxHealth, float healthRegen)
    {
        health.text = (int)currentHealth + "/" + maxHealth + " +" + healthRegen;
    }
}
