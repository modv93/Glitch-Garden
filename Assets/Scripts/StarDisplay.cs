using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {
	private Text starText;
	private int starCount = 100;
	public enum status {Success, Failure};
	// Use this for initialization
	void Start () {
		starText = GetComponent<Text>();
		UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddStars(int amount){
		starCount += amount;
		UpdateDisplay();
		//print (amount + "Stars have been added to display board");
	}
	public status UseStars(int amount){
		//use the stars for defenders 4
		if(starCount >= amount){
			starCount -= amount;
			UpdateDisplay();
			return status.Success;
		}
		return status.Failure;
	}
	private void UpdateDisplay(){
		starText.text = starCount.ToString();
	}
}
