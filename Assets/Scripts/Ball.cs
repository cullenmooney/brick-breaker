using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Paddle paddle;

	private bool gameStarted = false;

	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			// Locking the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse click to launch ball
			if (Input.GetMouseButtonDown(0)) {
				gameStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
