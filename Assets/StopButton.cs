using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		levelManager.LoadLevel("01a Start");
	}
}
