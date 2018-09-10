using UnityEngine;
using System.Collections; 
using UnityEngine.Advertisements;

public class player : MonoBehaviour {
	public int MoveDistance; 
	 float startpos;
	 float endpos;
	 float diffrence; 
	 bool move; 
	public GameObject playerShooter; 
	public GameObject playerBullet; 
	public float shootTimer = 0f; 
	public int positionX; 
	public Animator ani; 
	public bool alive; 
	public int scorem;
	public AudioSource audioSource; 
	public AudioClip explosion; 
	public int mode; 
	public GameObject bmi; 
	public GameObject bossmi;

	// Use this for initialization
	void Start () {
	
		ani = this.GetComponentInChildren<Animator>();   
		mode = 1;
		alive = true; 
		audioSource = this.GetComponent<AudioSource> ();  
		bmi = GameObject.FindGameObjectWithTag ("block_mode"); 
		if (bmi != null) {
			mode = 2;
		} 
		bossmi = GameObject.FindGameObjectWithTag ("boss_mode"); 
		if (bossmi != null) {
			mode = 3;
		} 
	}
	
	// Update is called once per frame
	void Update () {  
		if (alive) {
			Controls (); 
			scorem +=1;
		}
		transform.position = new Vector2 (positionX, transform.position.y);
	

		if (shootTimer > 0) {
			shootTimer -= 1 * Time.deltaTime; 
		} 
	} 

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.gameObject.tag == "enemy") {   
			gameOver();
			
		
			//Application.LoadLevel("restart_test_scene");
			//GameObject.Destroy(gameObject);

		}
	}  

	void FixedUpdate(){

	}

	IEnumerator som(){

		yield return new WaitForSeconds (2); 
		switch (mode) {
		case 1: 
			Advertisement.Show ();
			Application.LoadLevel ("restart_test_scene"); 
			break; 
		case 2: 
			Application.LoadLevel ("block_restart_test_scene");  
			break;  
		case 3: 
			Application.LoadLevel("boss_restart"); 
			break;
		}

	}
	void Controls(){
		if (Input.GetKeyDown (KeyCode.UpArrow) && transform.position.y < 3 ) {
			//this.GetComponent<Rigidbody2D>().position = new Vector2(this.GetComponent<Rigidbody2D>().position.x,this.GetComponent<Rigidbody2D>().position.y + MoveDistance); 
			transform.position = new Vector2(this.transform.position.x,transform.position.y + MoveDistance);
		} 
		if (Input.GetKeyDown (KeyCode.DownArrow)&& transform.position.y > -3 ) {
			//this.GetComponent<Rigidbody2D>().position = new Vector2(this.GetComponent<Rigidbody2D>().position.x,this.GetComponent<Rigidbody2D>().position.y - MoveDistance); 
			transform.position = new Vector2(this.transform.position.x,transform.position.y - MoveDistance);
		}  
		if (Input.GetKeyDown ("space")&& shootTimer <= 0 && alive) {
			Instantiate (playerBullet, playerShooter.transform.position, playerShooter.transform.rotation); 
			shootTimer = 0.2f;
		}
		//touch controls 
		if (Input.touchCount > 0) { 
			
			Touch touch = Input.GetTouch (0); 
			switch (touch.phase) {
			case TouchPhase.Began:  
				startpos = touch.position.y;   
				break;
			case TouchPhase.Ended: 
				endpos = touch.position.y;  
				if (transform.position.y > -3) {
					if (startpos - endpos > 20) { 
						this.GetComponent<Rigidbody2D> ().position = new Vector2 (this.GetComponent<Rigidbody2D> ().position.x, this.GetComponent<Rigidbody2D> ().position.y - MoveDistance);
					}
				}  
				if (transform.position.y < 3) {
					if (startpos - endpos < -20) { 
						this.GetComponent<Rigidbody2D> ().position = new Vector2 (this.GetComponent<Rigidbody2D> ().position.x, this.GetComponent<Rigidbody2D> ().position.y + MoveDistance);
					}
				}  
				if(!(startpos - endpos <-20) && !(startpos - endpos > 20) &&(alive)){
					Instantiate (playerBullet, playerShooter.transform.position, playerShooter.transform.rotation); 
					shootTimer = 0.25f;
				}
				break;
			} 


		} 
			}  
	public void gameOver(){
		alive = false; 
		audioSource.clip = explosion; 
		audioSource.Play(); 
		StartCoroutine("som");
		ani.SetBool("isDead",true); 
		this.GetComponent<Collider2D>().enabled = false; 
		
	}
	
			
			
		}
	

