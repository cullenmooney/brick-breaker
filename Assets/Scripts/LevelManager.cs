using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load request for " + name);
		Application.LoadLevel(name);
	}

	public void QuitGame () {
		Debug.Log("Quitting Game");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}

