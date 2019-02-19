using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : Singleton<UI_Game> {

	[SerializeField]
	private Text timeText;
	[SerializeField]
	private GameObject finishPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = TimeManager.Instance.GetTimeText ();
	}

	public GameObject GetFinishPanel(){
		return finishPanel;
	}
}
