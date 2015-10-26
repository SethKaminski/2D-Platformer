using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float speed = 100f;
	public Transform groundCheck;
	public Transform wallCheck;

	private Rigidbody2D rb;
	private Transform tr;
	//private Animator anim;
	
	private bool grounded = false;
	//private bool _groundAhead = true;
	

	void Start ()
	{
		this.rb = gameObject.GetComponent<Rigidbody2D> ();
		this.tr = gameObject.GetComponent<Transform> ();
		//this.anim = gameObject.GetComponent<Animator> ();
	}

	void FixedUpdate ()
	{
		if (this.grounded) {
			//this.anim.SetInteger("AnimState", 1);
			this.rb.velocity = new Vector2 (this.tr.localScale.x, 0) * this.speed;
			
			bool groundAhead = Physics2D.Linecast(transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
			Debug.DrawLine(transform.position, this.groundCheck.position);

			LayerMask mask = 1 << LayerMask.NameToLayer ("Ground");
			mask |= 1 << LayerMask.NameToLayer ("Enemy");
			
			bool wallAhead = Physics2D.Linecast(this.wallCheck.position, this.wallCheck.position, mask);

			if(!groundAhead || wallAhead) {
				flip ();
			}
			
		} else {
			//this.anim.SetInteger("AnimState", 0);
		}
	}
	
	void OnCollisionStay2D(Collision2D otherCollider)
	{
		if (otherCollider.gameObject.CompareTag ("Ground"))
		{
			this.grounded =  true;
		}
	}
	
	void OnCollisionExit2D(Collision2D otherCollider)
	{
		if (otherCollider.gameObject.CompareTag ("Ground"))
		{
			this.grounded =  false;
		}
	}
	
	// PRIVATE METHODS
	private void flip()
	{
		if (this.tr.localScale.x == 1)
		{
			this.tr.localScale = new Vector3(-1f, 1f, 1f); 
		}
		else
		{
			this.tr.localScale = new Vector3(1f, 1f, 1f);
		}
	}
	
}
