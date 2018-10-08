using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public int playerOneScore;
	public int playerTwoScore;
	public BallScript gameBall;
	public Text player1Text;
	public Text player2Text;


	// Use this for initialization
	void Start () {
		playerOneScore = 0;
		playerTwoScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoalScored(int playerNumber)
	{
		// increase the score for whichever player scored
		if (playerNumber == 1) {
			playerOneScore++;
			player1Text.text = playerOneScore.ToString ();
			gameBall.Reset ();
		} else if (playerNumber == 2) {
			playerTwoScore++;
			player2Text.text = playerTwoScore.ToString ();
			gameBall.Reset ();
		}
		// now check if the player has won
		if(playerOneScore == 3)
			GameOver(1);
		else if (playerTwoScore == 3)
			GameOver(2);
	}

	void GameOver(int winner)
	{
		// this is called when a player reaches 3 points 

		// reset the scores
		playerOneScore = 0;
		playerTwoScore = 0; 
		player1Text.text = playerOneScore.ToString ();
		player2Text.text = playerTwoScore.ToString ();
		gameBall.Reset ();
	}
}
