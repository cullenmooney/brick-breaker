using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private bool gameStarted = false;

	private Vector3 paddleToBallVector;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		audioSource = GetComponent<AudioSource>();
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

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(0f, .2f), Random.Range(0f, .2f));
		if (gameStarted) {
			audioSource.Play();
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
