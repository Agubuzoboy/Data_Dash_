using UnityEngine;
using System.Collections;

public class player_bullet : MonoBehaviour {
	public float speed; 
	public float lifeSpan; 
	public float lifeTime = 0;
	public float inc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime += inc * Time.deltaTime; 
		
		if (lifeTime >= lifeSpan) {
			Destroy(gameObject);
		}
	} 

	void FixedUpdate(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed , 0); 
	} 

	void OnCollisionEnter2D(Collision2D coll){ 
		Destroy (gameObject);


	}
}
