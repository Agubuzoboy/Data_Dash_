using UnityEngine;
using System.Collections;

public class beam_1 : MonoBehaviour {

	player player; 
	float timer = 3;
	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<player> ();
	}
	
	// Update is called once per frame
	void Update () { 
		if(transform.localScale.x < 7){
			transform.localScale = new Vector2 (transform.localScale.x +10 * Time.deltaTime, transform.localScale.y); 
			transform.position = new Vector2 (transform.position.x -15f * Time.deltaTime, transform.position.y);}

		timer -= 1 * Time.deltaTime; 
		if (timer <= 0) {
			Destroy(gameObject);
		}
	} 

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.tag == "player") {
			player.gameOver();
		}

	}
}
