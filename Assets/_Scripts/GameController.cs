using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public int score;
	public int lives;

	public Text scoreText;
	public Text scoreLives;

	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
		UpdateLives();
		UpdateScore();
	}

	void Update()
	{
		if (lives <= 0)
		{
			Destroy(Player);
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}
	
	private void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void subLive(int newLivesValue)
	{
		lives -= newLivesValue;
		UpdateLives();
	}
	
	private void UpdateLives()
	{
		scoreLives.text = "Lives: " + lives;
	}
}
