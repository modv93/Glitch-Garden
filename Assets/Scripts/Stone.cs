using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {
	private Attacker attacker;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D collider){
		attacker = collider.gameObject.GetComponent<Attacker>();
		if(attacker && !attacker.GetComponent<Fox>()){
			anim.SetTrigger("underAttack trigger");
		}
	}
}
