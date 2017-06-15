using UnityEngine;
using System.Collections;

public class TreatSpawner : MonoBehaviour {

	public GameObject[] treatSpawn; 
	public float delayTimer;

	private float timer;
	private float maxPos = 2.5f;
	private float time = 0.0f;
	private int MIN_BALLS;
	private float interpolationPeriod = 25f;
	private int numberBalls;
	// Use this for initialization
	void Start () {
		timer = delayTimer;
		MIN_BALLS = 2;
		numberBalls =treatSpawn.Length;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		time += Time.deltaTime;

		if (time >= interpolationPeriod && (numberBalls > MIN_BALLS)) {
			time = time - interpolationPeriod;
			numberBalls -=1;
			print ("NUMBER OF BALLS Update: " + numberBalls);
			print ("Timer is " + timer);
			delayTimer += 0.07f;
		}
		if (timer <= 0) {
			Vector3 treatSpawnPoint = new Vector3 (Random.Range (-maxPos, maxPos), transform.position.y, transform.position.z);
			Instantiate (treatSpawn[Random.Range(0,numberBalls)], treatSpawnPoint, transform.rotation);
			timer = delayTimer;
		}
	}
}