using UnityEngine;
using System.Collections;

public class bit : MonoBehaviour {
	public garbage_collector gc;  
	public float XSpeed;
	public float bitX; 
	public float bitY; 
	public GameObject bitgo;  
	public AudioSource audioSource; 
	public AudioClip ping;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType<garbage_collector> (); 
		audioSource = this.GetComponent<AudioSource> ();  
		this.GetComponent<Collider2D>().enabled = true; 
		this.GetComponentInChildren<SpriteRenderer>().enabled = true;
		//audioSource.clip = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (XSpeed * gc.multiplyer, 0);  
	} 

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "player") {  
			this.GetComponent<Collider2D>().enabled = false; 
			this.GetComponentInChildren<SpriteRenderer>().enabled = false;
			audioSource.clip = ping; 
			audioSource.Play();
			gc.bits +=1; 
			instan(); 
			StartCoroutine(waitBeforeKill());


		} 

		if (coll.gameObject.tag == "gc") {

			instan();
			Destroy(gameObject);

		}

	}  

	void instan(){
		int level = Random.Range (1, 4); 
		switch(level){
		case 1: 
			bitY = -3.5f; 
			break; 
		case 2: 
			bitY = 0; 
			break; 
		case 3: 
			bitY = 3.5f; 
			break;
		}

		Instantiate(bitgo, new Vector2 (transform.position.x + bitX, bitY), transform.rotation);


	} 

	IEnumerator waitBeforeKill(){
		yield return new WaitForSeconds (1);
		Destroy(gameObject);

	}
}
