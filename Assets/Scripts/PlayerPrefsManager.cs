using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
	
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume(float Volume){
		if(Volume>=0 && Volume<=1){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, Volume);
		}
		else{
			Debug.LogError("Master volume out of bounds");
		}
	}
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	public static void UnlockLevel(int level){
		if(level<=Application.levelCount-1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);  //using 1 for true #No bools :'(
		}
		else{
			Debug.LogError("Trying to unlock a level not in build order");
		}
	}
	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		if(level <= Application.levelCount-1){
			return isLevelUnlocked;
		}
		else {
			Debug.LogError("Trying to unlock a level not in build order");
			return false;
		}
	}
	public static void SetDifficulty(float Difficulty){
		if(Difficulty >= 0f && Difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, Difficulty);
		}
		else{
			Debug.LogError("Difficulty out of range");
		}
	}
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
