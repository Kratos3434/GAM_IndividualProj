using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    //!todo: Modify this script!!!
    [SerializeField] MinionMovement mv;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform detectPoint;
    [SerializeField] private float detectRange = 1.1f;
    // Start is called before the first frame update

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (mv.tag == "ally minion")
    //    {
    //        print(collision.gameObject.tag);
    //        if (collision.gameObject.tag == "enemy")
    //        {
    //            mv.SetMinionRB(collision.gameObject);
    //            mv.SetMinionInRange(true);
    //        }
    //    } else
    //    {
    //        if (collision.gameObject.tag == "ally minion")
    //        {
    //            print("Enemy detect ally minion");
    //            mv.SetMinionRB(collision.gameObject);
    //            mv.SetMinionInRange(true);
    //        }
    //        else if (collision.gameObject.tag == "Player")
    //        {
    //            if (!mv.IsMinionInRange())
    //            {
    //                mv.SetPlayerInRange(true);
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (mv.tag == "ally minion")
    //    {

    //    }
    //    else
    //    {
    //        if (collision.gameObject.tag == "Player")
    //        {
    //            mv.SetPlayerInRange(false);
    //        }
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //   if (mv.tag == "ally minion")
    //    {
    //        if (collision.gameObject.tag == "enemy")
    //        {
    //            mv.SetMinionRB(collision.gameObject);
    //            mv.SetMinionInRange(true);
    //        }
    //    }
    //}

    private void FixedUpdate()
    {
        Detect();
    }

    void Detect()
    {
        Collider2D[] detectEnemies = Physics2D.OverlapCircleAll(detectPoint.position,detectRange, enemyLayers);

        if (detectEnemies.Length > 0 )
        {
            foreach (Collider2D enemy in detectEnemies)
            {
                if (mv.tag == "ally minion")
                {
                    if (enemy.tag == "enemy")
                    {
                        //print("Ally minion detect enemy");
                        mv.SetMinionRB(enemy.gameObject);
                        mv.SetMinionInRange(true);
                    }
                    else
                    {
                        mv.SetMinionRB(null);
                        mv.SetMinionInRange(false);
                    }
                }
                else if (mv.tag == "enemy")
                {
                    if (enemy.tag == "ally minion")
                    {
                        //print("Enemy detect ally minion");
                        mv.SetMinionRB(enemy.gameObject);
                        mv.SetMinionInRange(true);
                    }
                    else if (enemy.tag == "Player")
                    {
                        //print("Player in range");
                        if (!mv.IsMinionInRange())
                        {
                            mv.SetPlayerInRange(true);
                        }
                    }
                }
            }
        } else
        {
            mv.SetMinionRB(null);
            mv.SetMinionInRange(false);
            mv.SetPlayerInRange(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (detectPoint != null)
        {
            Gizmos.DrawWireSphere(detectPoint.position, detectRange);
        }
    }
}
