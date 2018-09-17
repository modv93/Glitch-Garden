﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelmanager;
	private MusicManager musicmanager;
	// Use this for initialization
	void Start () {
		musicmanager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicmanager.ChangeVolume(volumeSlider.value);
	}
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelmanager.LoadLevel("01a Start");
	}
	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
}
