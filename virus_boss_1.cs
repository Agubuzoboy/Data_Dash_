using UnityEngine;
using System.Collections;

public class virus_boss_1 : MonoBehaviour { 
	public int health;
	public bool bossEnabled;  
	public bool bossPresented; 
	public float attackReady; 
	public GameObject bullet; 
	public GameObject shooter;  
	public GameObject beamer;
	public bool testshoot;  
	public GameObject laser; 
	public GameObject lasero; 
	public bool laseron; 
	public player player; 
	SpriteRenderer sr;  
	Animator ani; 
	public GameObject BlockVirusGameobject;
	public GameObject redVirus;
	public GameObject shooterVirus;
	public GameObject blueVirus; 
	public GameObject yellowVirus;

	garbage_collector gc; 



	// Use this for initialization
	void Start () {  
		health = 50;
		bossEnabled = false;  
		attackReady = 0f;
		gc = GameObject.FindObjectOfType<garbage_collector> (); 
		player = GameObject.FindObjectOfType<player> (); 
		sr = GetComponentInChildren<SpriteRenderer> (); 
		ani = this.GetComponentInChildren<Animator>(); 
		ani.SetBool ("charge", false);
	
	}
	
	// Update is called once per frame
	void Update () {  

		if (gc.bossModeTimer <= 0) {
			bossEnabled = true;
		}

		//turn bossEnabled to true when gc timer is up 

		if ((bossPresented == true)&& (attackReady <= 0)) {
			selectAttack();
		}  

		if((bossPresented) && (attackReady >= 0)){
			attackReady -= 1 * Time.deltaTime;
		}

			
	

		//test bools for attack 

		if (testshoot) {
			blast(); 

		}  



		if (health <= 0) {
			gc.destroymini = true; 
			gc.destroyMiniEni ();
			Destroy(gameObject);
		}
	
	} 

	void FixedUpdate(){

		if (bossEnabled) { 

			if((GetComponent<Rigidbody2D>().position.x != 5.75f) && (GetComponent<Rigidbody2D>().position.x > 5.75f)) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(-1,0);} 
			else{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			}
		} 

		if (GetComponent<Rigidbody2D> ().position.x <= 5.75f) {
			bossPresented = true;
		}
	}  

	void  OnTriggerEnter2D(Collider2D coll){
		if ((coll.tag == "bullet")&& (bossPresented)) { 
			health -=5; 
			StartCoroutine(changeColorWhenHit());
		}

	}

	void selectAttack(){ 

		if (transform.position.y != 3.5) {
			int attackId = Random.Range (1, 4); 
			switch (attackId) { 
			case 1: 
				blast ();  
				break; 
			case 2: 
				shoot (); 
				break; 
			case 3: 
				swarm (); 
				break;
			}
		} else {
			shoot();
		}
		attackReady = 6f;
	} 

	void blast(){  

		ani.SetBool ("charge", true);
		StartCoroutine (beam ());
		laseron = true;
		testshoot = false;


	} 

	void shoot(){  

		StartCoroutine (wait ());  


	} 

	void swarm(){  

		int level = Random.Range(1,4);  
		int enemyId = Random.Range(1,6); 
		float enemyY; 


		for (int i = 0; i < 5; i++) {
			switch (level) {
			case 1: 
				enemyY = -3.5f; 
				break; 
			case 2: 
				enemyY = 0; 
				break; 
			case 3: 
				enemyY = 3.5f; 
				break; 
			default: 
				enemyY = 0; 
				break;
			
			} 
		
			switch (enemyId) { 
			case 1: 
				Instantiate (BlockVirusGameobject, new Vector2 (transform.position.x + RandomX (), enemyY), Quaternion.identity); 
				break; 
			case 2: 
				Instantiate (redVirus, new Vector2 (transform.position.x + RandomX (), enemyY), Quaternion.identity); 
				break;
			case 3: 
				Instantiate (shooterVirus, new Vector2 (transform.position.x + RandomX (), enemyY), Quaternion.identity);  
				break; 
			case 4: 
				Instantiate (blueVirus, new Vector2 (transform.position.x + RandomX (), enemyY), Quaternion.identity);  
				break;  
			case 5: 
				Instantiate (yellowVirus, new Vector2 (transform.position.x + RandomX (), enemyY), Quaternion.identity);  
				break; 
			
			}
		}
	
		/*int level = Random.Range(1,4); 
		float enemyY;
		for(int i = 0; i < 5; i++){
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
			default:
				enemyY = 0; 
				break;
		} 
		
	
			Instantiate(BlockVirusGameobject,new Vector2 (transform.position.x + RandomX(),enemyY),Quaternion.identity); 
			 }  
	*/	StartCoroutine (killAfterSpawn ());

	} 

	IEnumerator wait(){
		int pn;  
		Vector3 p; 
		for (int i = 0; i< 5; i++) {
			pn = Random.Range (1, 4); 
			switch (pn) {
			case 1: 
				p = new Vector3 (transform.position.x, 0, 0);  
				break; 
			case 2: 
				p = new Vector3 (transform.position.x, 3.5f, 0); 
				break; 
			case 3: 
				p = new Vector3 (transform.position.x, -3.5f, 0); 
				break; 
			default: 
				p = new Vector3 (transform.position.x, 0, 0); 
				break; 
			} 
			
			transform.position = p; 
			yield return new WaitForSeconds (0.5f);
			Instantiate (bullet, shooter.transform.position, transform.rotation); 
			yield return new WaitForSeconds (0.5f); 


			
		}
	} 

	IEnumerator changeColorWhenHit(){

		sr.color = Color.red; 
		yield return new WaitForSeconds (0.5f); 
		sr.color = Color.white;
	} 

	IEnumerator beam(){ 
		yield return new WaitForSeconds (0.5f);  
		ani.SetBool ("charge", false);
		Instantiate (laser, beamer.transform.position, beamer.transform.rotation); 

	} 

	float RandomX(){
		return Random.Range (50, 100);
	}  

	IEnumerator killAfterSpawn(){ 
		yield return new WaitForSeconds (5);
		gc.destroymini = true; 
		gc.destroyMiniEni ();
	}
}
