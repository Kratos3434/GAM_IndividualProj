using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProtectorAttack : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1.1f;
    [SerializeField] private SpawnProjectile spawnProjectile;

    private float nextAttackTime = 0f;
    //[SerializeField] private Transform projectilePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / 1f;

        }
    }

    void Attack()
    {
        //print("Current target: " + currentTarget);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        if (hitEnemies.Length > 0 )
        {
            Collider2D enemy = hitEnemies[0];

            Transform playerTransform = enemy.GetComponent<Transform>();
            //Debug.Log("We hit " + enemy.name);
            if (gameObject.tag == "enemy protector")
            {
                if (enemy.tag == "ally minion")
                {
                    //Transform playerTransform = enemy.GetComponent<Transform>();
                    //Instantiate(prefab, transform.position, transform.rotation);
                    spawnProjectile.Spawn(playerTransform);
                }
                else if (enemy.tag == "Player")
                {
                    //Transform playerTransform = enemy.GetComponent<Transform>();
                    //Instantiate(prefab, transform.position, transform.rotation);
                    GetComponent<AudioSource>().Play();
                    spawnProjectile.Spawn(playerTransform);
                }
            }
            else
            {
                if (enemy.tag == "enemy")
                {
                    //Transform playerTransform = enemy.GetComponent<Transform>();
                    //Instantiate(prefab, transform.position, transform.rotation);
                    spawnProjectile.Spawn(playerTransform);
                }
            }

        }
        else
        {
             
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
