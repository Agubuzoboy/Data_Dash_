 using UnityEngine;
using System.Collections;

public class virus_bullet : MonoBehaviour {  
	public garbage_collector gc;
	public float speed; 
	public float lifeSpan; 
	public float lifeTime = 0;
	public float inc;  
	public float cy;


	// Use this for initialization
	void Start () { 
		cy = transform.position.y;
		gc = GameObject.FindObjectOfType<garbage_collector> (); 
	}
	
	// Update is called once per frame
	void Update () { 
		transform.position = new Vector2 (transform.position.x, cy);
		lifeTime += inc * Time.deltaTime; 

		if (lifeTime >= lifeSpan) {
			Destroy(gameObject);
		}
	} 

	void FixedUpdate(){
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (gc.multiplyer*speed, 0);
	}
	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.collider.gameObject.tag == "enemy") {
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),coll.gameObject.GetComponent<Collider2D>());
		} 
		if (coll.collider.gameObject.tag == "bullet") {
			Destroy(gameObject);
		} 

		if (coll.collider.GetComponent<virus_bullet> () != null) {
			Destroy(gameObject);
		}
		
		
	} 
}
