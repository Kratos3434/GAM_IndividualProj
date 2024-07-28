using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protector : IBaseStats
{
    [SerializeField] private ProtectorHealthBar healthBar;
    [SerializeField] GameObject prefab;
 
    void Start()
    {
        this.SetMaxHealth(1000f);
        this.SetHealth(this.GetMaxHealth());
        healthBar.SetMaxHealth(this.GetMaxHealth());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetHealth() <= 0f)
        {
            Vector3 pos = transform.position;
            pos.y = -1.66f;
            Instantiate(prefab, pos, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        print("Taking damage");
        this.SetHealth(this.GetHealth() - damage);
        healthBar.SetHealth(this.GetHealth(), this.GetMaxHealth());
    }
}
