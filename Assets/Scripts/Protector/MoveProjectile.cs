using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private Transform target;
    private float speed = 5f;
    [SerializeField] private ProtectorAttack pa;

    void Update()
    {
        Vector3 pos = target.transform.position;
        pos.y = -3.5f;
        Vector3 direction = pos - transform.position;
        movement = direction;
    }

    private void FixedUpdate()
    {

        Move(movement);
        if (target == null)
        {
            //gameObject.GetComponent<Projectile>().Destruct();
            pa.GetComponent<Projectile>().Destruct();
        }
    }

    void Move(Vector2 direction)
    {
        //print(rb.transform.position.y);
        rb.MovePosition((Vector2)transform.position + (direction * 0.6f * (Time.deltaTime * speed)));
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        //rb.velocity = sp.up * speed;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
