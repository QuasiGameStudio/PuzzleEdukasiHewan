using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController> {

	public void RestartScene (){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void NextFruit (){
		if (GameData.Instance.GetChoosedFruitIndex () == 26) {
			int nextFruitIndex = 0;
			GameData.Instance.SetChoosedFruitIndex (nextFruitIndex);
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		} else {
			int nextFruitIndex = GameData.Instance.GetChoosedFruitIndex () + 1;
			GameData.Instance.SetChoosedFruitIndex (nextFruitIndex);
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

	}

	public void GoToScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void Quit(){
		Application.Quit ();
	}
}
