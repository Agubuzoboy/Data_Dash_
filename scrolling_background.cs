using UnityEngine;
using System.Collections;

public class scrolling_background : MonoBehaviour {
	public float scrollSpeed; 
	public float v2; 

	public float offset; 
	public garbage_collector gc;
	// Use this for initialization
	void Start () {
	
		gc = GameObject.FindObjectOfType<garbage_collector> ();

	}
	
	// Update is called once per frame
	void Update () {   

		offset = GetComponent<Renderer> ().material.mainTextureOffset.x;

		v2 = scrollSpeed * Time.deltaTime * gc.multiplyer;
		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (offset += v2,0);
	}
}
