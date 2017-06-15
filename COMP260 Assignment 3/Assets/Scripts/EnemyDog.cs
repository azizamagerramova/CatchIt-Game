using UnityEngine;
using System.Collections;

public class EnemyDog : MonoBehaviour {


	public float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range (3f, 15f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (0, speed * Time.deltaTime));

	}
}
