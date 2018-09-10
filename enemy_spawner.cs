using UnityEngine;
using System.Collections;

public class enemy_spawner : MonoBehaviour {
	public float timer = 0f;  
	public float timeinc;
	public float spawntime; 
	public int enemyId; 
	public int enemyYId; 
	public float enemyY;
	public GameObject block_virus;  
	public GameObject red_virus; 
	public float multiplyer = 1f; 
	public float inc = 0.025f;
	public float incs = 0.001f;  
	public int maxvalue =2; 
	public garbage_collector gc;  
	public scanner sc;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindObjectOfType<garbage_collector> (); 
		sc = GameObject.FindObjectOfType<scanner> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += timeinc * Time.deltaTime;  

		//spawntime -= incs * Time.deltaTime;



	} 

	void spawn(){
		enemyYId = Random.Range (1, 4);
		enemyId = Random.Range (1, maxvalue);  

		switch (enemyYId) {
		case 1: 
			enemyY = -3.5f; 
			break; 
		case 2: 
			enemyY = 0f; 
			break;
		case 3: 
			enemyY = 3.5f; 
			break;


		}

		switch (enemyId) {
		case 1:  
			Instantiate(block_virus,new Vector2 (transform.position.x,enemyY),transform.rotation); 
			break;  

		case 2: 
			Instantiate(red_virus,new Vector2 (transform.position.x,enemyY),transform.rotation); 
			break;

	} 
		//timer = 0; 
		gc.spawn = false;
} 
	void FixedUpdate(){ 
		if ( gc.spawn == true) {
			spawn(); 
			
		}

		if (multiplyer <= 4) {
			multiplyer += inc * Time.deltaTime;  
		} else {
			maxvalue =3;
		}
	}
}