using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSword : MonoBehaviour
{
    [SerializeField] Player player;
    private float attackTime = 0f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(10f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        attackTime += Time.deltaTime;

        if (attackTime >= 1f)
        {
            if (collision.gameObject.tag == "Player")
            {
                player.TakeDamage(10f);
            }
            attackTime = 0f;
        }
    }
}
