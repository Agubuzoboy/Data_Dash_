using UnityEngine;
using System.Collections;

public class garbage_collector : MonoBehaviour { 
	public bool spawn; 
	public float multiplyer; 
	public float inc; 
	public int bits; 
	public int playerScore; 
	public int enemyKilled;  
	public player player; 
	public int highscore; 
	public GameObject bmi;
	public bool blockMode;  
	public GameObject bossmi; 
	public bool bossMode;
	public int block_highscore; 
	public float bossModeTimer; 
	public bool destroymini;

	// Use this for initialization
	void Start () { 
		blockMode = false; 
		bossMode = false;
		player = FindObjectOfType<player> ();
		multiplyer = 1; 
		bits = 0; 
		playerScore = 0; 
		enemyKilled = 0; 
		highscore = PlayerPrefs.GetInt ("highscore"); 
		bmi = GameObject.FindGameObjectWithTag ("block_mode");  
		bossmi = GameObject.FindGameObjectWithTag ("boss_mode"); 
		if (bmi != null) {
			blockMode = true; 
			block_highscore = PlayerPrefs.GetInt("block_highscore");
		} 
		if (bossmi != null) {
			bossMode = true;  
			bossModeTimer = 20f;
			destroymini = true;
			//block_highscore = PlayerPrefs.GetInt("block_highscore");
		} 

	}
	
	// Update is called once per frame
	void Update () {  



			multiplyer += inc * Time.deltaTime; 

		if (multiplyer >= 6) {
			multiplyer = 6;
		}

		if (bossMode) {

			if(bossModeTimer >= 0){
				bossModeTimer -= 1 * Time.deltaTime; }

			if(bossModeTimer <= 0){

				destroyMiniEni();
				} 

			} 


	if (blockMode == false) {
			playerScore = (player.scorem + (bits * 2) + enemyKilled);  
			PlayerPrefs.SetInt ("playerscore", playerScore);

			if (playerScore > highscore) {
				highscore = playerScore; 
				PlayerPrefs.SetInt ("highscore", playerScore); 
				Debug.Log (highscore);
			}
		} 

		if (blockMode) {
			playerScore = player.scorem + (bits * 2) ;  
			PlayerPrefs.SetInt ("block_playerscore", playerScore); 

			if (playerScore > block_highscore) {
				block_highscore = playerScore; 
				PlayerPrefs.SetInt ("block_highscore", playerScore); 
				Debug.Log (block_highscore);
			}
		}
		//if (enemyKilled > 0) {
			//enemyKilled = 0; //resets it
		//}
	

	
	} 

	void OnCollisionEnter2D(Collision2D coll){
		GameObject.Destroy (coll.gameObject); 

		/*if (coll.gameObject.tag == "enemy") {
			spawn = true;
		}*/
	} 

public void destroyMiniEni(){ 

		if (destroymini) {
			GameObject[] minienemies = GameObject.FindGameObjectsWithTag ("enemy"); 
			for (int i = 0; i < minienemies.Length; i++) {
				Destroy (minienemies [i]); 
				} 
			destroymini = false;
		}
	}
}