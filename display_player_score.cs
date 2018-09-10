using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class display_player_score : MonoBehaviour {
	public int playerscore; 
	public string playerscoretext; 
	public string score;
	// Use this for initialization
	void Start () {
		playerscore = PlayerPrefs.GetInt (score);  //what score are you displaying for which mode
		playerscoretext = playerscore.ToString();	
		this.GetComponent<Text> ().text = "Player Score:" + playerscoretext;

	}
	
	// Update is called once per frame
	void Update () { 

	
	}
}
