using UnityEngine;
using System.Collections;

public class shooter_virus : MonoBehaviour {
	public float XSpeed; 
	public int YSpeed;   
	public GameObject BlockVirusGameobject;  
	public GameObject redVirus; 
	public GameObject shooterVirus;  
	public GameObject blueVirus; 
	public GameObject yellowVirus;
	public GameObject shooter; 
	public GameObject bullet;
	public int SpaceOut; 
	int level;  
	public float enemyY;
	public garbage_collector gc;
	public Vector2 speed; 
	public int enemyId; 
	public int maxValue = 2; 
	public float shootTimer = 0;   
	public float shootTime; 
	public Animator ani; 
	public Collider2D[] colliders; 
	public bool alive; 
	public float cy; 
	public AudioSource audioSource; 
	public AudioClip explosion;



	// Use this for initialization
	void Start () { 
		cy = transform.position.y;
		gc = GameObject.FindObjectOfType<garbage_collector> (); 
		ani = this.GetComponentInChildren<Animator>();  
		ani.SetBool ("isDead", false);
		maxValue = 4; 
		colliders = this.GetComponents<Collider2D>();
		colliders [0].enabled = true; 
		colliders [1].enabled = true; 
		alive = true;  
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame 

		


	void FixedUpdate () {
		move ();
	} 

	void Update(){ 
		transform.position = new Vector2 (transform.position.x, cy);

	
		shootTimer += 1 * Time.deltaTime; 
		if ((shootTimer > shootTime)&& alive) {
			shoot(); 
			shootTimer = 0;
		}

		if (gc.multiplyer > 1.7) {
			maxValue = 5;
		} 
		if (gc.multiplyer > 2) {
			maxValue = 6;
		}


	}
	void OnTriggerEnter2D(Collider2D coll){ 
		
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
				Instantiate(redVirus,new Vector2 (transform.position.x +RandomX() ,enemyY),transform.rotation); 
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
			alive = false;  
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
			ani.SetBool("isDead",true); 
			StartCoroutine(killAfterAni());
			//GameObject.Destroy (gameObject);
		}

	} 
	void move(){ 
		

		speed = GetComponent<Rigidbody2D> ().velocity = new Vector2 (XSpeed * gc.multiplyer, YSpeed);  

		
		
	} 

	void shoot(){
		Instantiate (bullet, shooter.transform.position, shooter.transform.rotation);

	} 
	float RandomX(){
		return Random.Range (50, 100);
	} 

	IEnumerator killAfterAni(){ 
		yield return new WaitForSeconds (0.5f); 
		Destroy (gameObject);
	}
} 


