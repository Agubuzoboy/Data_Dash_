using UnityEngine;
using System.Collections;

public class red_virus : MonoBehaviour {
	public int XSpeed; 
	public int YSpeed; 
	public float Multiplyer = 1;  
	public float Increm;
	public int SpaceOut;  
	int level; 
	public GameObject redVirus;  
	public GameObject BlockVirusGameobject;   
	public GameObject blueVirus;
	public GameObject shooterVirus; 
	public GameObject yellowVirus;
	public int enemyId;
	public enemy_spawner enemyspawner;  
	public garbage_collector gc;
	public float enemyY;  
	public int maxValue = 3; 
	public Animator ani; 
	public Collider2D[] colliders; 
	public float cy; 
	public AudioSource audioSource; 
	public AudioClip explosion;


	// Use this for initialization
	void Start () {
		//enemyspawner = GameObject.FindObjectOfType<enemy_spawner> ();  
		cy = transform.position.y;

		gc = GameObject.FindObjectOfType<garbage_collector> (); 
		ani = this.GetComponentInChildren<Animator>();  
		colliders = this.GetComponents<Collider2D>();
		colliders [0].enabled = true; 
		colliders [1].enabled = true; 
		ani.SetBool ("isDead", false); 
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame  
	void Update(){
		transform.position = new Vector2 (transform.position.x, cy);
	}

	void FixedUpdate () {
		move (); 


	} 
	void OnTriggerEnter2D(Collider2D coll){ 

		/*if (coll.gameObject.name == "player") { 
			level = Random.Range(1,4); 
			
			switch(level){
			case 1:
				GameObject NewRedVirus = (GameObject)Instantiate(RedVirusGameobject, new Vector2 (transform.position.x + SpaceOut, -3.5f),transform.rotation); 
				break;  
			case 2:  
				NewRedVirus = (GameObject)Instantiate(RedVirusGameobject, new Vector2 (transform.position.x + SpaceOut, 0f),transform.rotation);  
				break; 
			case 3:  
				NewRedVirus = (GameObject)Instantiate(RedVirusGameobject, new Vector2 (transform.position.x + SpaceOut, 3.5f),transform.rotation);  
				break;
			}
		}*/ 

		/*if (coll.gameObject.name == "garbage_collector") {
			Destroy(gameObject); 
		}*/ 

		if (coll.gameObject.name == "player") { 
			level = Random.Range(1,4);  
			enemyId = Random.Range(1,maxValue);
			
			switch(level){
			case 1: 
				enemyY = -3.5f; 
				break; 
			case 2: 
				enemyY = 0; 
				break; 
			case 3: 
				enemyY = 3.5f; 
				break;
				
			} 
			
			switch(enemyId){ 
			case 1: 
				Instantiate(BlockVirusGameobject,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation); 
				break; 
			case 2: 
				Instantiate(redVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation); 
				break; 
			case 3: 
				Instantiate(shooterVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation);  
				break; 
			case 4 : 
				Instantiate(blueVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation);  
				break;  
			case 5 : 
				Instantiate(yellowVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation);  
				break; 
				
			}
		}
	}  

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.gameObject.tag == "enemy") {
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),coll.gameObject.GetComponent<Collider2D>());
		} 

		if (coll.collider.gameObject.tag == "bullet") {   

			colliders[0].enabled = false; 
			colliders[1].enabled = false;  
			audioSource.clip = explosion; 
			audioSource.Play();
			gc.enemyKilled += 10;
			level = Random.Range(1,4);  
			enemyId = Random.Range(1,maxValue);

			switch(level){
			case 1: 
				enemyY = -3.5f; 
				break; 
			case 2: 
				enemyY = 0; 
				break; 
			case 3: 
				enemyY = 3.5f; 
				break;
				
			} 
			
			switch(enemyId){ 
			case 1: 
				Instantiate(BlockVirusGameobject,new Vector2 (transform.position.x +RandomX() ,enemyY),transform.rotation); 
				break; 
			case 2: 
				Instantiate(redVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation); 
				break; 
			case 3: 
				Instantiate(shooterVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation);  
				break;
			case 4 : 
				Instantiate(blueVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation);  
				break; 	 
			case 5 : 
				Instantiate(yellowVirus,new Vector2 (transform.position.x + RandomX(),enemyY),transform.rotation);  
				break; 
			} 
			ani.SetBool("isDead",true); 
			StartCoroutine(killAfterAni());
			//GameObject.Destroy (gameObject);
		}

	}
	void move(){ 
		//float multiplyer = enemyspawner.multiplyer;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (XSpeed * gc.multiplyer , YSpeed);  
		if (gc.multiplyer > 1.5) {
			maxValue = 4;
		} 
		if (gc.multiplyer > 1.7) {
			maxValue = 5;
		} 
		if (gc.multiplyer > 2) {
			maxValue = 6;
		}

		

		
	} 
	float RandomX(){
		return Random.Range (50, 100);
	} 

	IEnumerator killAfterAni(){ 
		yield return new WaitForSeconds (0.5f); 
		Destroy (gameObject);
	}
}
