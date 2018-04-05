using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of brick count
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			CueParticleSmoke();
			Destroy(gameObject);

		} else {
			LoadSprites();
		}
		//SimulateWin ();
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

	}

	// TODO Remove this method once we actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}

	void CueParticleSmoke () {
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
}
