using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]//Protection mechanism, adds attacker script to the object if not available.
public class Lizard : MonoBehaviour {
	private Attacker attacker;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log("Fox collided with " + collider);
		GameObject obj = collider.gameObject;
		if(!obj.GetComponent<Defenders>()){
			return;
		}
		anim.SetBool("isAttacking", true);
		attacker.Attack(obj);
	}
}
