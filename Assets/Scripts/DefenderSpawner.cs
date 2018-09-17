using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Vector2 position = SnapToGrid(CalculateWorldPointOfClick());
		GameObject defender = Button.selectedDefender;
		if(defender){
			int defenderCost = defender.GetComponent<Defenders>().starCost;
			//int defenderCost = defender.GetComponent<Defenders>().starCost;
			if(starDisplay.UseStars(defenderCost) == StarDisplay.status.Success){
				SpawnDefender (position, defender);
			}else{
				Debug.Log("Insufficient stars");
			}
		}
	}
	
	void SpawnDefender (Vector2 position, GameObject defender)
	{
		GameObject newDefender = Instantiate (defender, position, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPOS){
		float newX = Mathf.RoundToInt(rawWorldPOS.x);
		float newY = Mathf.RoundToInt(rawWorldPOS.y);
		return new Vector2 (newX, newY);
	}
	
	Vector2 CalculateWorldPointOfClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float DistanceFromCamera = 10f;
		Vector3 weirdTriplet = new Vector3(mouseX,mouseY,DistanceFromCamera);
		Vector3 worldPOS = myCamera.ScreenToWorldPoint(weirdTriplet);
		return worldPOS;
	}
}
