using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour {

	[SerializeField]
	bool isPlayerTwo;
	[SerializeField]
	float moveSpeed = 0.01f;       // how far the paddle moves per frame
	float currentSpeed;
	public float maxSpeed = 0.2f;

	public GameObject ball;

	int direction = 0;
	float oldPosX;

	public bool AI;

	// Use this for initialization
	void Start () {
		oldPosX = transform.position.x;
	}

	// FixedUpdate is called once per physics tick/frame
	void FixedUpdate () {
		if (!AI) {
			// first decide if this is player 1 or player 2 so we know what keys to listen for
			if (isPlayerTwo) {
				if (Input.GetKey ("z"))
					MoveLeft ();
				else if (Input.GetKey ("x"))
					MoveRight ();
				else
					NoKey ();
			} else { // if not player 2 it must be player 1
				if (Input.GetKey ("n"))
					MoveLeft ();
				else if (Input.GetKey ("m"))
					MoveRight ();
			}
		}



		if (AI) {
			if (!isPlayerTwo && ball.transform.position.y < 0f) {
				if (ball.transform.position.x > transform.position.x) {
					MoveRight ();
				} else if (ball.transform.position.x < transform.position.x) {
					MoveLeft ();
				}
			}

			if (isPlayerTwo && ball.transform.position.y > 0f) {
				if (ball.transform.position.x > transform.position.x) {
					MoveRight ();
				} else if (ball.transform.position.x < transform.position.x) {
					MoveLeft ();
				}
			}
		}


		if (oldPosX > transform.position.x) {
			direction = -1;
		} else if (oldPosX < transform.position.x) {
			direction = 1;
		} else {
			direction = 0;
		}
	}

	void LateUpdate () {

		oldPosX = transform.position.x;

	}

	void OnCollisionExit2D(Collision2D other) {
		float dirAdjust = 5 * direction;
		other.rigidbody.velocity = new Vector2 (other.rigidbody.velocity.x + dirAdjust, other.rigidbody.velocity.y);
	}

	// move the player's paddle up by an amount determined by 'speed'
	void MoveLeft()
	{
		if (currentSpeed < maxSpeed) {
			currentSpeed += moveSpeed;
		}
		transform.position = new Vector2(transform.position.x - currentSpeed, transform.position.y);
	}

	// move the player's paddle down by an amount determined by 'speed'
	void MoveRight()
	{
		if (currentSpeed < maxSpeed) {
			currentSpeed += moveSpeed;
		}
		transform.position = new Vector2 (transform.position.x + currentSpeed, transform.position.y);            
	}

	void NoKey()
	{
		if (currentSpeed < 0f) {
			currentSpeed += moveSpeed;
		} else if (currentSpeed > 0f) {
			currentSpeed -= moveSpeed;
		}
	}
}
