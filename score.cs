using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class score : MonoBehaviour {

	public string tx;  

	public garbage_collector gc;
	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = "Score:0";
		gc = GameObject.FindObjectOfType<garbage_collector> (); 
	}
	
	// Update is called once per frame
	void Update () { 


		tx = gc.playerScore.ToString (); 
		this.GetComponent<Text> ().text ="Score:"+ tx;

	
	}
}
