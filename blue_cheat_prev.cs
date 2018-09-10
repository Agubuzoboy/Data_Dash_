using UnityEngine;
using System.Collections;

public class blue_cheat_prev : MonoBehaviour {
	public int count;  
	public GameObject block;
	//block_virus parent;
	
	// Use this for initialization
	void Start () {
		count = 0;  
		//parent = this.GetComponentInParent<block_virus> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (block == null) {
			count = 0;
		}
		
	} 
	
	void OnTriggerStay2D(Collider2D coll){
		if ((coll.gameObject.GetComponent<blue_virus>() != null) && (coll.isTrigger == false)){ 
			block = coll.gameObject;
			count++;
		}
	}  
	
	
	
	public void DestroyCheat(){
		Destroy (block);
		
	}
}
