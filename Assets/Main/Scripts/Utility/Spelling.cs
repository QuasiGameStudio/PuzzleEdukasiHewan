using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spelling : Singleton<Spelling> {

	[SerializeField]
	private Transform fruitParent;

	[SerializeField]
	private Text fruitNameText;

	[SerializeField]
	private AudioClip[] charClips;

	[SerializeField]
	private AudioClip[] nameClips;

	private string word;
	private string[] characters;

	private AudioSource audioSource;


	//string gender
	private string male = "M";
	private string female = "F";

	//string tune
	private string normalTune = "normal";
	private string highTune = "high";

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		
		word = GameManager.Instance.GetFruitName().ToUpper();

		characters = new string[word.Length];
		for (int i = 0; i < word.Length; i++)
		{			
			characters[i] = System.Convert.ToString(word[i]);
			Debug.Log (characters[i]);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpelling(){
		Debug.Log ("StartSpelling");
		StartCoroutine (SpellingLetter ());
	}

	public IEnumerator SpellingLetter(){

		for (int i = 0; i < characters.Length; i++) {	
			
			//write fruit name text one by one

			fruitNameText.text = fruitNameText.text + characters [i] + " ";

			if (i == characters.Length - 1) {
				
				PlayLetterClip (female, characters [i], highTune);

			} else {
				
				PlayLetterClip (female, characters [i], normalTune);

			}

			yield return new WaitForSeconds (1);
		}

		yield return new WaitForSeconds (0.1f);
		PlayFullNameClip ();
		UI_Game.Instance.GetFinishPanel ().transform.GetChild (0).GetChild (0).gameObject.SetActive (true);

		yield return new WaitForSeconds (1);

		//AdsManager.Instance.CheckAdsIsEnable ();

	}

	void PlayLetterClip(string gender,string char_, string tune){

		string clipName = "char" + gender + "-" + char_ + "-" + tune;

		foreach (AudioClip clip in charClips) {			
			if (clipName == clip.name) {
				audioSource.PlayOneShot (clip);
			}
		}
	}

	void PlayFullNameClip(){


		string clipName = word.ToLower();

		foreach (AudioClip clip in nameClips) {			
			if (clipName == clip.name) {
				audioSource.PlayOneShot (clip);

			}
		}
	}




}