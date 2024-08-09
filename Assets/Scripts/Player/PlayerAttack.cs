using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Player attacker;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackRange = 0.5f;
    //[SerializeField] private Minion minion;
    [SerializeField] PlayerStatsUI playerStatsUI;
    private float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        playerStatsUI.setMinionsKilled(attacker.GetMinionsKilled());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attacker.GetAttackSpeed();
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        GetComponent<AudioSource>().Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "enemy")
            {
                Minion minion = enemy.GetComponent<Minion>();
                minion.TakeDamage(attacker.GetAttackDamage());
                if (minion != null)
                {
                    minion.TakeDamage(attacker.GetAttackDamage());
                    if (minion.GetHealth() <= 0f)
                    {
                        minion.ShowCoin();
                        attacker.SetGold(attacker.GetGold() + minion.GetWorth());
                        playerStatsUI.SetGoldEarned(attacker.GetGold());
                        attacker.SetMinionsKilled(attacker.GetMinionsKilled() + 1);
                        playerStatsUI.setMinionsKilled(attacker.GetMinionsKilled());
                    }
                }
            } else if (enemy.tag == "enemy protector")
            {
                Protector protector = enemy.GetComponent<Protector>();
                protector.TakeDamage(attacker.GetAttackDamage());
                if (protector.GetHealth() <= 0f)
                {
                    playerStatsUI.SetGoldEarned(500);
                }
            }else if (enemy.tag == "boss")
            {
                Boss boss = enemy.GetComponent<Boss>();
                boss.TakeDamage(attacker.GetAttackDamage());
                if (boss.GetHealth() <= 0f)
                {
                    playerStatsUI.SetGoldEarned(1000);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
 
}
