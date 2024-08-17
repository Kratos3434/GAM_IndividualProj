using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : IBaseStats
{

	public Transform player;
    public float maxhealth;

	public bool isFlipped = false;

    public Animator animator;

    [SerializeField] private BossHealth healthBar;

    void Start()
    {
        this.SetMaxHealth(maxhealth);
        this.SetHealth(this.GetMaxHealth());
        healthBar.SetMaxHealth(this.GetMaxHealth());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetHealth() <= 0f)
        {
            
            animator.SetTrigger("death");
        }
    }

    public void TakeDamage(float damage)
    {
        this.SetHealth(this.GetHealth() - damage);
        healthBar.SetHealth(this.GetHealth(), this.GetMaxHealth());
    }

    public void win()
    {
        Destroy(gameObject);
        ChangeScene.MoveToScene(3);
    }

    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

}
