using UnityEngine;
using System.Collections; 

public class block_virus : MonoBehaviour {
	public int XSpeed; 
	public int YSpeed; 
	public float Multiplyer = 1;  
	public float Increm;
	public GameObject BlockVirusGameobject;  
	public GameObject redVirus; 
	public GameObject shooterVirus; 
	public GameObject blueVirus; 
	public GameObject yellowVirus;
	public int SpaceOut; 
	int level;  
	public float enemyY;
	public enemy_spawner enemyspawner;  
	public garbage_collector gc;
	public Vector2 speed; 
	public int enemyId; 
	public int maxValue = 2; 
	public float cy; 
	public top_cheat_prev[] tcp;  
	public GameObject bmi; 
	public bool blockMode;
	// Use this for initialization
	void Start () {  
		blockMode = false;
		cy = transform.position.y;
		enemyspawner = GameObject.FindObjectOfType<enemy_spawner> (); 
		gc = GameObject.FindObjectOfType<garbage_collector> (); 
		tcp = this.GetComponentsInChildren<top_cheat_prev> (); 
		bmi = GameObject.FindGameObjectWithTag ("block_mode"); 
		if (bmi != null) {
			blockMode = true;
		}
	}
	
	// Update is called once per frame 
	void Update(){
		transform.position = new Vector2 (transform.position.x, cy); 

		if ((tcp[0].count >= 1)&&(tcp[1].count >= 1)) {
			makeItFair();
		}
	}

	void FixedUpdate () {
		move ();
	} 

	void OnTriggerEnter2D(Collider2D coll){ 

		if (coll.gameObject.name == "player") { 
			level = Random.Range(1,4);  
			enemyId = Random.Range(1,maxValue); 
			if(blockMode){
				enemyId = 1;
			}

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
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),coll.gameObject.GetComponent<Collider2D>());
		}
	} 
	void move(){ 

		Multiplyer += 0.05f * Time.deltaTime;
		 speed = GetComponent<Rigidbody2D> ().velocity = new Vector2 (XSpeed * gc.multiplyer, YSpeed);  
		if (gc.multiplyer > 1.3) {
			maxValue = 3;
		} 
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

	void makeItFair(){  
		level = Random.Range(1,4);  
		enemyId = Random.Range(1,maxValue); 
		if (blockMode) {
			enemyId = 1;
		}

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

		int num = Random.Range (0, 2);  


		switch (num) {
		case 0: 
			tcp[0].DestroyCheat(); 
			break; 
		case 1: 
			tcp[1].DestroyCheat(); 
			break;

		} 
	
	}
} 


