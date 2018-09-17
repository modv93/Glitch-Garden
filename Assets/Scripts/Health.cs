using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void dealDamage(float damage){
		health -= damage;
		if(health <= 0){
			DestroyGameOBJ();
		}
	}
	public void DestroyGameOBJ(){
		Destroy(gameObject);
	}
}
