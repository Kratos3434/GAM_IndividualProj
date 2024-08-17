using UnityEngine;
using System.Collections;

public class Simple2DMove : MonoBehaviour {
	private float horizontal;
	private float speed = 8f;
	private float jumpingPower = 20f;
	private bool isFacingRight = true;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] Animator animator;
	[SerializeField] private VirtualCamera cam;
	
	// Update is called once per frame
	void Update () {
        Collider2D[] layers = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);

        horizontal = Input.GetAxisRaw("Horizontal");

		animator.SetFloat("speed", Mathf.Abs(horizontal));

		if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
		}

		if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}

        if (layers.Length > 0 && layers[0].tag == "platform")
        {
			//print(layers[0].name);
            cam.ModifyHeight(0.6f);
        } else
		{
			cam.ModifyHeight(0.812f);
		}

		Flip();
	}

	private void FixedUpdate ()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}

	private bool IsGrounded()
	{

        return Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer).Length > 0;
	}

	private void Flip()
	{
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

//Credits to this video: https://www.youtube.com/watch?v=K1xZ-rycYY8
