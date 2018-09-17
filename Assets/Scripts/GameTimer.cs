using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float levelSeconds = 100;
	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
		audioSource.Stop();
		findWinLabel ();
		winLabel.SetActive(false);
		}

	void findWinLabel ()
	{
		winLabel = GameObject.Find ("You Win");
		if (winLabel) {
			Debug.LogWarning ("Please create You Win label");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad/levelSeconds;
		if(Time.timeSinceLevelLoad/levelSeconds > 1 && !isEndOfLevel){
			HandleWinCondition (); 
		}
	}

	void HandleWinCondition ()
	{	
		DestroyAllTaggedObjects();
		audioSource.Play ();
		audioSource.volume = 0.5f;
		winLabel.SetActive (true);
		Invoke ("LevelComplete", audioSource.clip.length);
		isEndOfLevel = true;
	}
	//Destroy all tagged objects 
	void DestroyAllTaggedObjects(){
		GameObject[] winDestroyObj = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach(GameObject obj in winDestroyObj){
			if(obj){
				Destroy(obj);
			}
		}
	}
	void LevelComplete(){
		levelManager.LoadNextLevel();
		Debug.Log("Complete");
	}
}
