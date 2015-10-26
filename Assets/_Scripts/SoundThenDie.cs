using UnityEngine;
using System.Collections;

public class SoundThenDie : MonoBehaviour {
	
	private AudioSource aS;
	private SpriteRenderer sr;

	void Start ()
	{
		this.aS = GetComponent<AudioSource> ();
		this.sr = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (this.sr.enabled == true)
		{
			this.aS.Play();
			this.sr.enabled = false;

			Invoke("Die", this.aS.clip.length);
		}
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}
