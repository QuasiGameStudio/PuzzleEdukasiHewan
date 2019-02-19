using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData> {

	// Use this for initialization
	void Start () {
		//ResetData ();
	}

	public void ResetData(){
		PlayerPrefs.DeleteAll ();
	}

	public void SetChoosedFruitIndex(int index){
		string key = "ChoosedFruitIndex";
		PlayerPrefs.SetInt (key, index);
	}
	public int GetChoosedFruitIndex(){
		string key = "ChoosedFruitIndex";
		return PlayerPrefs.GetInt (key, 0);
	}

	public void SetFruitBestTime(int fruitIndex, float value){
		string key = "BestTime_" + fruitIndex;
		PlayerPrefs.SetFloat (key, value);		
	}

	public float GetFruitBestTime(int fruitIndex){
		string key = "BestTime_" + fruitIndex;
		return PlayerPrefs.GetFloat (key,1000);		
	}


	//ads
	public void SetAdsIsEnable(string adsName,int value){

		string key = adsName + "IsEnable";

		PlayerPrefs.SetInt (key, value);

	}
	public int GetAdsIsEnable(string adsName){

		string key = adsName + "IsEnable";

		return PlayerPrefs.GetInt (key,GetAdsWaitingTimes());
	}

	int GetAdsWaitingTimes(){
		return -3;
	}

}
