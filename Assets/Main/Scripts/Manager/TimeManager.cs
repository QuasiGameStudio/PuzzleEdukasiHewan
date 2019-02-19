using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : Singleton<TimeManager> {

	//[SerializeField]
	private float time;
	private float minutes;
	private float seconds;

	[SerializeField]
	private string timeText;

	[SerializeField]
	private AudioClip timerClip;

	//[SerializeField]
	//private Color redColorTime;

	// Use this for initialization
	void Start () {
		
		timeText = Mathf.RoundToInt (minutes).ToString ("00") + ":" + Mathf.RoundToInt (seconds).ToString ("00");
		
	}
		
	// Update is called once per frame
	void Update () {

		if (GameManager.Instance.GetGameIsPlaying ()) {
			time += Time.deltaTime;

			minutes = Mathf.Floor (time / 60);
			seconds = time % 60;

			timeText = Mathf.RoundToInt (minutes).ToString ("00") + ":" + Mathf.RoundToInt (seconds).ToString ("00");

			if (!GetComponent<AudioSource> ().isPlaying) {
				GetComponent<AudioSource> ().clip = timerClip;
				GetComponent<AudioSource> ().Play ();
			}				

		} else {

			if (GetComponent<AudioSource> ().isPlaying)
				GetComponent<AudioSource> ().Stop ();

		}

		//set text red color
		//if(time <= 29.5f){
			//timeText.color = redColorTime;
		//}
	}
		
	public void CheckFruitBestTime(){		
		if (time < GameData.Instance.GetFruitBestTime (GameData.Instance.GetChoosedFruitIndex ())) {
			GameData.Instance.SetFruitBestTime (GameData.Instance.GetChoosedFruitIndex (),time);
		}				
	}

	public string GetTimeText (){
		return timeText;
	}

}
