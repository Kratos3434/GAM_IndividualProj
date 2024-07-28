using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class IBaseStats: MonoBehaviour
{                               
    private float maxHealth;                                                            
    private float health;
    //private float maxMana;
    //private float mana;
    //private float baseHealthRegen;
    //private float healthRegen;
    //private int armor;
    private float baseAttackDamage;
    private float attackDamage;
    //private float baseMovementSpeed;
    //private float movementSpeed;
    //private float attackRange;
    private float baseAttackSpeed;
    private float attackSpeed;

    public float GetMaxHealth()
    {
        return this.maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public float GetHealth() { return this.health; }

    public void SetHealth(float health) {  this.health = health; }

    public float GetAttackDamage()
    {
        return this.attackDamage;
    }

    public void SetBaseAttackDamage(float damage)
    {
        this.baseAttackDamage = damage;
    }

    public void SetAttackDamage(float damage) 
    {
        this.attackDamage = damage;
    }

    public float GetBaseAttackDamage()
    {
        return this.baseAttackDamage;
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
    }

    public void SetBaseAttackSpeed(float baseAttackSpeed)
    {
        this.baseAttackSpeed = baseAttackSpeed;
    }

    public float GetAttackSpeed() { return this.attackSpeed; }

    public float GetBaseAttackSpeed()
    {
        return this.baseAttackSpeed;
    }
}
