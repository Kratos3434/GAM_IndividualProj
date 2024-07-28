using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player: IBaseStats
{
    //float this.GetMaxHealth() = 500f;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerHealthText playerHealthText;
    [SerializeField] PlayerStatsUI playerStatsUI;
    float healthRegen = 0.9f;
    private float attackRange = 0.5f;
    private int gold = 0;
    private float time;
    private int minionsKilled = 0;

    void Awake()
    {
        this.SetMaxHealth(500);
    }

    void Start()
    {
        this.SetBaseAttackDamage(70f);
        this.SetAttackDamage(GetBaseAttackDamage());
        this.SetHealth(this.GetMaxHealth());
        this.SetBaseAttackSpeed(0.79f);
        this.SetAttackSpeed(GetBaseAttackSpeed());
        playerHealth.SetMaxHealth(this.GetHealth());
        playerHealthText.setHealthText(this.GetHealth(), this.GetMaxHealth(), healthRegen);

        playerStatsUI.SetAttackDamage(GetAttackDamage());
        playerStatsUI.SetAttackSpeed(GetAttackSpeed());
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHealth() <= 0f)
        {
            ChangeScene.MoveToScene(2);
        }
        if (this.GetHealth() < this.GetMaxHealth())
        {
            time += Time.deltaTime;
        }
        if (time >= 1f)
        {
            if (this.GetHealth() < this.GetMaxHealth())
            {
                if ((this.GetHealth() + healthRegen) > this.GetMaxHealth())
                {
                    this.SetHealth(this.GetMaxHealth());
                }
                else
                {
                    this.SetHealth(this.GetHealth() + healthRegen);
                }
                playerHealth.SetHealth(this.GetHealth());
                playerHealthText.setHealthText(this.GetHealth(), this.GetMaxHealth(), healthRegen);
            }
            time = 0f;
        }
    }

    public void TakeDamage(float damage)
    {
        this.SetHealth(this.GetHealth() - damage);
        playerHealth.SetHealth(this.GetHealth());
        playerHealthText.setHealthText(this.GetHealth(), this.GetMaxHealth(), healthRegen);

    }

    public float GetAttackRange()
    {
        return this.attackRange;
    }

    public int GetMinionsKilled()
    {
        return minionsKilled;
    }

    public void SetMinionsKilled(int minionsKilled)
    {
        this.minionsKilled = minionsKilled;
    }

    public int GetGold()
    {
        return this.gold;
    }

    public void SetGold(int gold) {  this.gold = gold; }
}
