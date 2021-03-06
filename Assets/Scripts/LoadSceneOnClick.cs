﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex) {
		SceneManager.LoadScene (sceneIndex);
	}

	public void StartGame() {
		SceneManager.LoadScene ("GameScene");
	}

	public void MainMenu() {
		SceneManager.LoadScene ("MainMenuScene");
	}
		
	public void EndGame() {
		SceneManager.LoadScene ("RestartScene");
	}
}
