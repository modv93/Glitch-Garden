using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	//Alternate :	//private SpriteRenderer sprite;
	//private bool selected = false;
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	private Button[] buttonArray;
	private Text costText;
	// Use this for initialization
	void Start () {
		//sprite = GetComponent<SpriteRenderer>();
		//sprite.color = Color.black;
		//Alternate : 
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		if(!costText){Debug.LogWarning(name + " has no cost");}
		costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		//Alternate
		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		//selected = !selected;
		//if(sprite){
			//if(selected){
			//	sprite.color = Color.white;
			//	//Debug.Log("Selected");
			//}
			//else{
			//	sprite.color = Color.black;
			//}
	//	}
		print (name + " Pressed");
	}
}
