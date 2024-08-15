using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage = 15f;
    //[SerializeField] ProtectorAttack pa;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public float GetDamage()
    {
           return this.damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "ally protector")
        {
            if (collision.gameObject.tag == "enemy")
            {
                Minion minion = collision.gameObject.GetComponent<Minion>();
                minion.TakeDamage(this.damage);
                Destruct();
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                Player player = collision.gameObject.GetComponent<Player>();
                player.TakeDamage(this.damage);
                Destruct();
            } else if (collision.gameObject.tag == "ally minion")
            {
                Minion minion = collision.gameObject.GetComponent<Minion>();
                minion.TakeDamage(this.damage);
                Destruct();
            }
        }
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }
}
