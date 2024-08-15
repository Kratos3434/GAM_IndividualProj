using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float speed = 2f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        animator.SetBool("isMoving", true);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Die()
    {
        animator.SetTrigger("Death");
    }
}
