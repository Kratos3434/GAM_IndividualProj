using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackRange = 1.1f;
    [SerializeField] private Minion attacker;
    [SerializeField] MinionMovement minionMovement;

    private float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attacker.GetAttackSpeed();

        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //animator.SetTrigger("attack");

        if (hitEnemies.Length > 0 )
        {
            GetComponent<AudioSource>().Play();
            Collider2D enemy = hitEnemies[hitEnemies.Length - 1];

            //Debug.Log("We hit " + enemy.name);
            if (gameObject.tag == "ally minion")
            {
                if (enemy.tag == "enemy")
                {
                    //print("ally minion attacking enemy");
                    //print(hitEnemies[hitEnemies.Length - 1]);
                    Minion minion = enemy.GetComponent<Minion>();
                    minion.GetComponent<MinionMovement>().SetCanMove(false);
                    minionMovement.SetCanMove(false);
                    minion.TakeDamage(attacker.GetAttackDamage());
                    animator.SetTrigger("attack");
                } else if (enemy.tag == "enemy protector")
                {
                    minionMovement.SetCanMove(false);
                    Protector protector = enemy.GetComponent<Protector>();
                    protector.TakeDamage(attacker.GetAttackDamage());
                    animator.SetTrigger("attack");
                }
            } else
            {
                if (enemy.tag == "ally minion")
                {
                    Minion minion = enemy.GetComponent<Minion>();
                    minion.GetComponent<MinionMovement>().SetCanMove(false);
                    minionMovement.SetCanMove(false);
                    minion.TakeDamage(attacker.GetAttackDamage());
                    animator.SetTrigger("attack");
                    //minion.TakeDamage(attacker.GetAttackDamage());
                } else if (enemy.tag == "Player")
                {
                    //minionMovement.SetCanMove(false);
                    minionMovement.SetCanMove(false);
                    enemy.GetComponent<Player>().TakeDamage(attacker.GetAttackDamage());
                    animator.SetTrigger("attack");
                } else if (enemy.tag == "ally protector")
                {
                    minionMovement.SetCanMove(false);
                    Protector protector = enemy.GetComponent<Protector>();
                    protector.TakeDamage(attacker.GetAttackDamage());
                    animator.SetTrigger("attack");
                }
            }
        } else
        {
            minionMovement.SetCanMove(true);
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
