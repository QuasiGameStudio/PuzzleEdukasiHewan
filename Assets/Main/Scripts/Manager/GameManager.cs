using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	[SerializeField]
	private GameObject[] fruits;

	private bool gameIsPlaying;

	[SerializeField]
	private GameObject fruitParent;

	[SerializeField]
	private GameObject baloons;

	private GameObject fruit;
	private string fruitName;

	//AudioClips
	[SerializeField]
	private AudioClip winClip;
	[SerializeField]
	private AudioClip[] gameClips;

	private int piecesCount;
	private int goal;

	void Awake(){
		GetComponent<AudioSource> ().clip = gameClips [Random.Range (0, 2)];
		SpawnFruit ();
	}

	// Use this for initialization
	void Start () {

		if (!GetComponent<AudioSource> ().isPlaying)
			GetComponent<AudioSource> ().Play ();

		piecesCount = fruit.transform.GetChild (3).childCount;
		goal = piecesCount / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckGoal(int matched){
//		Debug.Log ("Matched: " + matched);
		if (matched == goal) {
			
			StartCoroutine (FinishGame ());
		}
	}

	IEnumerator FinishGame(){
		SetGameIsPlaying (false);
		//Spawn Baloons
		Instantiate(baloons);
		//Stop Game music
		GetComponent<AudioSource> ().Stop();
		//Play win clip
		GetComponent<AudioSource> ().PlayOneShot (winClip);	
		//Disable Fruit Plate
		fruit.transform.GetChild(1).gameObject.SetActive(false);

		TimeManager.Instance.CheckFruitBestTime ();

		yield return new WaitForSeconds (3f);

		Spelling.Instance.StartSpelling ();

		UI_Game.Instance.GetFinishPanel ().SetActive (true);

	}

	void SpawnFruit(){
		fruit = Instantiate (fruits [GameData.Instance.GetChoosedFruitIndex()],fruitParent.transform);
		fruitName = fruits [GameData.Instance.GetChoosedFruitIndex ()].name;
	}

	public void SetGameIsPlaying(bool value){
		gameIsPlaying = value;
	}

	public bool GetGameIsPlaying(){
		return gameIsPlaying;
	}

	public string GetFruitName(){
		return fruitName;
	}
}
