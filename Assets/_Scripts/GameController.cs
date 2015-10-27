using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public int score;
	public int lives;

	public Text scoreText;
	public Text livesText;
	public Text GameOverText;
	public Text finleScoreText;

	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
		UpdateLives();
		UpdateScore();
		GameOverText.text = "";
		finleScoreText.text = "";
	}

	void Update()
	{
		if (lives <= 0)
		{
			Destroy(Player);
			GameOverText.text = "Game Over";
			finleScoreText.text = "Score: " + score;
			scoreText.text = "";
			livesText.text = "";
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
		livesText.text = "Lives: " + lives;
	}
}
