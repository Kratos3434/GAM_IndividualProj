using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : IBaseStats
{
    private float movementSpeed = 8f;
    private float time;
    [SerializeField] private MinionHealthBar healthBar;
    [SerializeField] Animator animator;
    [SerializeField] Image coinImage;
    [SerializeField] Image border;
    private int worth = 10;

    // Start is called before the first frame update
    void Start()
    {
        coinImage.enabled = false;
        this.SetMaxHealth(500f);
        this.SetHealth(this.GetMaxHealth());
        this.SetBaseAttackDamage(15f);
        this.SetAttackDamage(GetBaseAttackDamage());
        this.SetBaseAttackSpeed(1f);
        this.SetAttackSpeed(GetBaseAttackSpeed());
        time = 0f;
        healthBar.SetMaxHealth(GetMaxHealth());
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHealth() <= 0f)
        {
            border.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<MinionMovement>().enabled = false;
            gameObject.GetComponent<MinionAttack>().enabled = false;
            Invoke("DestroySelf", 0.5f);
        }
    }
    
    public void TakeDamage(float damage)
    {
        SetHealth(GetHealth() - damage);
        healthBar.SetHealth(GetHealth());
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetMinionHeallthBar(MinionHealthBar healthBar)
    {
        this.healthBar = healthBar;
    }

    public void ShowCoin()
    {
        coinImage.enabled = true;
    }

    public int GetWorth()
    {
        return this.worth;
    }
}
