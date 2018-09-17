using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {
	public GameObject[] spawnerPrefab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in spawnerPrefab){
			if(isTimeToSpawn(thisAttacker)){
				Spawner(thisAttacker);
			}
		}
	}
	void Spawner(GameObject thisAttacker){
		GameObject myAttacker = Instantiate(thisAttacker) as GameObject;
		myAttacker.transform.parent  = this.transform;
		myAttacker.transform.position = transform.position;
	}
	bool isTimeToSpawn(GameObject myGameObject){
		Attacker attacker = myGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnPerSecond = 1 / meanSpawnDelay;
		if(Time.deltaTime > spawnPerSecond){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		float threshold = spawnPerSecond * Time.deltaTime / 5;
		return (Random.value < threshold);//returnss a boolean value
	}
}
