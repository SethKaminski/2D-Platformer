using UnityEngine;
using System.Collections;

public class SoundThenDie : MonoBehaviour {

	private Rigidbody2D rb;
	private AudioSource aS;
	private SpriteRenderer sr;
	
	private float dieTime = 0;

	void Start ()
	{
		this.rb = GetComponent<Rigidbody2D>();
		this.aS = GetComponent<AudioSource> ();
		this.sr = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		if (this.dieTime > 0 && Time.time >= this.dieTime)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (this.dieTime == 0)
		{
			this.aS.Play();
			this.sr.enabled = false;
			this.dieTime = Time.time + this.aS.clip.length;
		}
	}
}
