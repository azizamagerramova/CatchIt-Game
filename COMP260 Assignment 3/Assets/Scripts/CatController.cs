using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {

	public float speed = 3;
	public float maxPosition = 2.4f;
	private float time = 0.0f;
	public float interpolationPeriod;

	private UIManager UIM;
	private Vector2 position;
	private Rigidbody2D rb2D;
	public AudioClip dogCollideClip;
	public AudioClip donutCollideClip;
	private AudioSource audio;
	public int life = 9;
	public int score = 0;
	// Use this for initialization
	void Start () {

		rb2D = GetComponent<Rigidbody2D> ();
		UIM = GameObject.FindObjectOfType<UIManager> ();
		position = new Vector2 (transform.position.x, transform.position.y);
		audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		float direction = Input.GetAxis ("Horizontal");
		position.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		position.x = transform.position.x;
		position.x = Mathf.Clamp (position.x, -maxPosition, maxPosition);
		transform.position = new Vector2 (position.x, position.y);

		if (direction < 0) {
			rb2D.velocity = new Vector2 (-speed, 0);
		} else if (direction > 0) {
			rb2D.velocity = new Vector2 (speed, 0);
		} else {
			rb2D.velocity = Vector2.zero;
		}
		transform.Translate(rb2D.velocity * Time.deltaTime, Space.Self);

		time += Time.deltaTime;

		if (time >= interpolationPeriod) {
			time = time - interpolationPeriod;
			speed += 0.2f;
		}
	}

	public void MoveLeft(){
		rb2D.velocity = new Vector2 (-speed, 0);
	}
	public void MoveRight(){
		rb2D.velocity = new Vector2 (speed, 0);
	}
	public void SetVelocityZero(){
		rb2D.velocity = Vector2.zero;

	}

	void OnCollisionEnter2D(Collision2D coll){
		GameObject collidingObj = coll.gameObject as GameObject;
		if (collidingObj.GetComponent<EnemyDog> ()) {
			life = life - 1;
			Destroy (collidingObj);
			UIM.lives.text = "Lives: " + life;
			audio.PlayOneShot(dogCollideClip);
			if (life == 0) {
				UIM.GameIsOver ();
				Destroy (gameObject);
			}
		}

		else if (collidingObj.GetComponent<TreatMove> ()) {
			score = score + 100;
			UIM.score.text = "Score: " + score;
			//audio.PlayOneShot(bonusCollideClip);
			Destroy (collidingObj);
		}

		else if (collidingObj.GetComponent<DonutMove> ()) {
			life = life + 1;
			print ("Lives are " + life);
			UIM.lives.text = "Lives: " + life;
			audio.PlayOneShot(donutCollideClip);
			Destroy (collidingObj);
		}
	}

}
