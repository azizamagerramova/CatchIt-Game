using UnityEngine;
using System.Collections;

public class EnemyDogShedder: MonoBehaviour {

	void OnCollisionEnter2D(Collision2D enemyCar){
		GameObject enemyCarCollided = enemyCar.gameObject as GameObject;
		if (enemyCarCollided.GetComponent<EnemyDog> ()) {
			Destroy (enemyCar.gameObject);
		}

		if (enemyCarCollided.GetComponent<TreatMove> ()) {
			print ("SUP");
			Destroy (enemyCar.gameObject);
		}
	}
}
