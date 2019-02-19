using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseFruits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AdMobManager.Instance.Set();		
		AdMobManager.Instance.ShowBanner();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowAd(){
		
		AdMobManager.Instance.ShowInterstitial("Game");
	}
}
