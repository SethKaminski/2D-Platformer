using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {
	
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	
	
	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		anim.SetBool("Grounded", grounded);
		
		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}
	}
	
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		
		if (h * rb.velocity.x < maxSpeed)
			rb.AddForce(Vector2.right * h * moveForce);
		
		if (Mathf.Abs (rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);

		anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		
		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();
		
		if (jump)
		{
			rb.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Coin")
		{

		}
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
