using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChooseFruit : MonoBehaviour {

	[SerializeField]
	private GameObject fruitGroups;
	private int fruitGroupIndex;

	private int fruitGroupCount;

	private GameObject prevButton;
	private GameObject nextButton;

	// Use this for initialization
	void Start () {

		//- 2 because 2 others is prevCatButton and nextCatButton
		fruitGroupCount = fruitGroups.transform.childCount - 2;

		prevButton = fruitGroups.transform.GetChild (fruitGroupCount).gameObject;
		nextButton = fruitGroups.transform.GetChild (fruitGroupCount + 1).gameObject;

		for (int i = 0; i < fruitGroupCount; i++) {
			SetFruitBestTimeTextOnGroup (i);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetFruitBestTimeTextOnGroup(int groupIndex){		

		for (int i = 0; i < 9; i++) {

			//convert time float to time string
			float time = GameData.Instance.GetFruitBestTime ((groupIndex * 10) + i - groupIndex);
			float minutes = Mathf.Floor (time / 60);
			float seconds = time % 60;
			string fruitBestTimeString = Mathf.RoundToInt (minutes).ToString ("00") + ":" + Mathf.RoundToInt (seconds).ToString ("00");
				
			if(GameData.Instance.GetFruitBestTime ((groupIndex * 10) + i - groupIndex) < 1000)
				fruitGroups.transform.GetChild (groupIndex).GetChild (i).GetChild (1).GetChild (0).GetComponent<Text> ().text = fruitBestTimeString;
		}


	}

	public void NextGroup(){
		if (fruitGroupIndex < fruitGroupCount - 1) {
			
			prevButton.SetActive (true);
			fruitGroups.transform.GetChild (fruitGroupIndex).gameObject.SetActive (false);
			fruitGroupIndex++;
			fruitGroups.transform.GetChild (fruitGroupIndex).gameObject.SetActive (true);
		} 

		if (fruitGroupIndex == fruitGroupCount - 1 ) {						
			nextButton.SetActive (false);
		}
	}

	public void PrevGroup(){
		if (fruitGroupIndex > 0) {
			nextButton.SetActive (true);
			fruitGroups.transform.GetChild (fruitGroupIndex).gameObject.SetActive (false);
			fruitGroupIndex--;
			fruitGroups.transform.GetChild (fruitGroupIndex).gameObject.SetActive (true);
		} 

		if (fruitGroupIndex == 0 ) {						
			prevButton.SetActive (false);
		}
	}
}
