using UnityEngine;
using System.Collections;

public class TreatShedder: MonoBehaviour {

	void OnCollisionEnter2D(Collision2D enemyCar){
		GameObject enemyCarCollided = enemyCar.gameObject as GameObject;
			Destroy (enemyCar.gameObject);

	}
}
