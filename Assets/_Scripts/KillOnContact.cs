using UnityEngine;
using System.Collections;

public class KillOnContact : MonoBehaviour {

	public int DMG;

	private AudioSource aS;
	private GameController gameController;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		else
		{
			Debug.Log("Cannot find 'GameController' script");
		}

		this.aS = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			gameController.subLive(DMG);
			aS.Play();
		}
	}
}
