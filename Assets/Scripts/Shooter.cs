using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile,gun;
	// Use this for initialization
	private Animator animator;
	private GameObject projectileParent;
	private AttackerSpawner myLaneSpawner;
	void Start(){
		animator = GetComponent<Animator>();
		//Creates a parent if necessary 
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
		print(myLaneSpawner);
	}
	void Update(){
		if(IsAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		}
		else{
			animator.SetBool("isAttacking", false);
		}
	}
	public void fire (){
		GameObject newProjectile = Instantiate(projectile)as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	public bool IsAttackerAheadInLane(){
		
		Attacker[] attacker = myLaneSpawner.GetComponentsInChildren<Attacker>();
		if(!(myLaneSpawner.transform.childCount <= 0)){
			foreach (Attacker currentAttacker in attacker){
				if(currentAttacker.transform.position.x >= transform.position.x){
					return true;
				}
			}
		}
		return false;
		//Ben's method, doesn't require attacker array
		/*
		if(myLaneSpawner.transform.childCount <= 0){return false;}
		foreach (Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x > transform.position.x){
				return true
			}
		}
		//attacker in lane behind us
		return false;
		*/
	}
	void SetMyLaneSpawner(){
		AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();
		foreach(AttackerSpawner spawner in spawnerArray){
			if(spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + "Couldn't find spawner in lane");
	}
}
