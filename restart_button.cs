using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
public class restart_button : MonoBehaviour {
	public string restartLevel;
	// Use this for initialization
	void Start () { 

		int rannum = Random.Range (0, 5); 

		switch (rannum) {

		
		case 1: 

			Advertisement.Show ();
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	} 

	void OnMouseDown(){ 
		PlayerPrefs.SetInt ("playerscore", 0); 
		PlayerPrefs.SetInt ("block_playerscore", 0); 


		/*int rannum = Random.Range (0, 4); 
		
		switch (rannum) {
		
		case 1: 
			
			Advertisement.Show ();
			break;
		}*/

		Application.LoadLevel (restartLevel); 
	}
}
