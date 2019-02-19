using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour {

	private float speed;
	private float rotatingSpeed;
	private float rotatingAngle;

	[SerializeField]
	private bool isConfetti;

	// Use this for initialization
	void Start () {
		speed = Random.Range (1, 2);
		rotatingSpeed = Random.Range (1, 3);
		rotatingAngle = Random.Range (-10 , 10);
	}
	
	// Update is called once per frame
	void Update () {

		if (isConfetti) {			
			transform.Translate (0, 2 * Time.deltaTime, 0);
			transform.Rotate (new Vector3 (0, 0, rotatingAngle) * Time.deltaTime * 20);
			Invoke ("DestroyConfetti",1.1f);
		} else {
			transform.Translate (0, speed * Time.deltaTime, 0);
			transform.Rotate (new Vector3 (0, 0, rotatingAngle) * Time.deltaTime * rotatingSpeed);
		}			
	}

	void DestroyConfetti(){
		Destroy (this.gameObject);
	}

	public void DestroyBaloon(){
		Destroy (this.gameObject);
	}
}
