using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutSpawner : MonoBehaviour {

	public GameObject[] treatSpawn; 
	public float delayTimer;

	private float timer;
	private float maxPos = 2.5f;
	private float time = 0.0f;
	private int MAX_DONUTS;
	private float interpolationPeriod = 15f;
	private int numberDonuts;
	// Use this for initialization
	void Start () {
		timer = delayTimer;
		numberDonuts = 1;
		MAX_DONUTS =treatSpawn.Length;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		time += Time.deltaTime;

		if (time >= interpolationPeriod && (numberDonuts < MAX_DONUTS)) {
			timer += (Time.deltaTime*2);
			numberDonuts += 1;
			delayTimer -= 0.2f;
		}
		if (timer <= 0) {
			Vector3 treatSpawnPoint = new Vector3 (Random.Range (-maxPos, maxPos), transform.position.y, transform.position.z);
			Instantiate (treatSpawn[Random.Range(0,numberDonuts)], treatSpawnPoint, transform.rotation);
			timer = delayTimer;
		}
	}
}
