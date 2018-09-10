using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class bits_ui : MonoBehaviour {

	// Use this for initialization
	public string tx;  
	
	public garbage_collector gc;
	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = "Bits:0";
		gc = GameObject.FindObjectOfType<garbage_collector> (); 
	}
	
	// Update is called once per frame
	void Update () { 
		
		
		tx = gc.bits.ToString (); 
		this.GetComponent<Text> ().text = "Bits:" + tx;
		
		
	} }