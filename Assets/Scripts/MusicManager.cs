using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;
	private AudioSource muse;
	// Use this for initialization
	void Start () {
		muse = GetComponent<AudioSource>();
		muse.volume = PlayerPrefsManager.GetMasterVolume();
	}
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelmusic = levelMusicChangeArray[level];
		if (thisLevelmusic){
			muse.clip = thisLevelmusic;
			muse.loop = true;
			muse.Play();
		}
		
	}
	public void ChangeVolume(float volume){
		muse.volume = volume;
	}
	
}
