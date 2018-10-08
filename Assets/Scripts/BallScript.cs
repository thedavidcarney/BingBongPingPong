using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	Rigidbody2D body;
    public float startSpeed = 50f;
	private bool roundInit = true;
	public Vector2 vel;
	public Vector2 minVel;
	public Vector2 maxVel;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		roundInit = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (roundInit) {
			body.AddForce(new Vector2(Random.Range(0f,250f), startSpeed));
			roundInit = false;
		}
		vel = body.velocity;
		if (vel.x > maxVel.x) {
			vel.x = maxVel.x;
		}
		if (vel.y > maxVel.y) {
			vel.y = maxVel.y;
		}
		if (vel.x < minVel.x) {
			vel.x = minVel.x;
		}
		if (vel.y < minVel.y) {
			vel.y = minVel.y;
		}
		body.velocity = vel;

	}
		
	public void Reset()
	{
		// reset the ball position and restart the ball movement
		body.velocity = Vector2.zero;
		transform.position = new Vector2(0,0);
		Start(); // restart the ball 
	}
}
