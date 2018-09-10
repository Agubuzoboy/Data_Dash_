using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class display_high_score : MonoBehaviour { 

	public int ihighscore; 
	public string highscore;

	// Use this for initialization
	void Start () { 
		ihighscore = PlayerPrefs.GetInt (highscore); 
		this.GetComponent<Text> ().text = "High Score:" + ihighscore;
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
