using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	private GameManager gm;

	[SerializeField]
	private GameObject confetti;
	[SerializeField]
	private AudioClip pieceMatchedClip;

	private int matched;

	void Awake(){
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>();
	}

	// Use this for initialization
	void Start () {
		Transform pieces = transform.GetChild (3);
		int firstT_ = (pieces.childCount / 2); 
		int j = 0;
		for (int i = firstT_; i < pieces.childCount; i++) {
			
			pieces.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().sprite = pieces.GetChild(j).GetComponent<SpriteRenderer>().sprite;
			j++;


		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Disable box collider to prevent piece moveable before reach target (after drag compleated) and after matched.
	public void DisableCollider(int draggableIndex){		
		transform.GetChild (3).GetChild (draggableIndex).GetComponent<BoxCollider2D> ().enabled = false;
	}

	//Temp
	public void StartingGame(){
		Debug.Log ("Starting Game");
		gm.SetGameIsPlaying (true);
	}

	public void Match(int draggableIndex){


		//Debug.Log ("Match! " + draggableIndex);

		//Instantiate confetti
		Instantiate (confetti, transform.GetChild (3).GetChild (draggableIndex).position, confetti.transform.rotation);

		transform.GetChild (3).GetChild (draggableIndex).GetComponent<AudioSource> ().PlayOneShot (pieceMatchedClip);

		//Add matched count
		matched++;
		//Check Goal
		gm.CheckGoal(matched);

	}


}
