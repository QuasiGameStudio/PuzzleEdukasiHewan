using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

	public GameObject[] particles;

	public Transform[] spawnPos;

	void Awake(){
		particles = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			particles [i] = transform.GetChild (i).gameObject;
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (ShootParticles());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShootParticles(){
		for (int i = 0; i < 25; i++) {
			if (!particles [Random.Range (0, particles.Length)].GetComponent<ParticleSystem> ().IsAlive () && !particles [Random.Range (0, particles.Length)].activeSelf) {			
				particles [Random.Range (0, particles.Length)].SetActive (true);
			}

			yield return new WaitForSeconds(2);
			particles [Random.Range (0, particles.Length)].SetActive (false);

		}

	}
}
