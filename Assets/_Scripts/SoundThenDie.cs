using UnityEngine;
using System.Collections;

public class SoundThenDie : MonoBehaviour {
	
	private AudioSource aS;
	private SpriteRenderer sr;
	private Collider2D cl;

	void Start ()
	{
		this.aS = GetComponent<AudioSource> ();
		this.sr = GetComponent<SpriteRenderer>();
		this.cl = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if (this.sr.enabled == true)
			{
				this.aS.Play();
				this.sr.enabled = false;
				this.cl.enabled = false;


				Invoke("Die", this.aS.clip.length);
			}
		}
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}
