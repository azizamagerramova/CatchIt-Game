using UnityEngine;
using System.Collections;

public class DogSpawner : MonoBehaviour {

	public GameObject[] dogsToSpawn; 
	public float delayTimer;
	public float speed = 5.0f;
	private float time = 0.0f;
	private int MAX_DOGGOS;
	private float interpolationPeriod = 10f;
	private int numberDoggos;

	private float timer;
	private float maxPos = 2.5f;
	// Use this for initialization
	void Start () {
		timer = delayTimer;
		numberDoggos = 5;
		MAX_DOGGOS =dogsToSpawn.Length;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime ;
		time += Time.deltaTime;

		if (time >= interpolationPeriod && (numberDoggos < MAX_DOGGOS)) {
			time = time - interpolationPeriod;
			numberDoggos +=1;
			delayTimer -= 0.1f;
		}
		print ("Delay timer is " + delayTimer);
		print ("number of doggos " + numberDoggos);
		if (timer <= 0) {
			Vector3 dogSpawnPoint = new Vector3 (Random.Range (-maxPos, maxPos), transform.position.y, transform.position.z);
			Instantiate (dogsToSpawn[Random.Range(4,numberDoggos)], dogSpawnPoint, transform.rotation);
			timer = delayTimer;
		}
	}
}
