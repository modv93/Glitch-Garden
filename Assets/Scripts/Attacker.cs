using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	//[Range (-1f, 2f)] add to dynamically set initalize variable in editor
	[Tooltip ("Average number of seconds between apperances")]
	public float seenEverySeconds;
	public float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;
	private
	// Use this for initialization
	void Start () {
		//Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		//myRigidBody.isKinematic = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget){
			anim.SetBool("isAttacking",false);
		}
	}
	//Collider2D collider | as parameters for the function onTrigger
	//void OnTriggerEnter2D(){
		//Debug.Log(name + " trigger enter");
	//}
	public void SetSpeed(float speed){
		currentSpeed  = speed;
	}
	//Called via Animator trigger to give damage
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.dealDamage(damage);
			}
		}
	}
	//Called via the child attacker obj. Inheritance is used, we  can also make the child class inherit tproperty.
	public void Attack (GameObject obj){
		//Debug.Log ("attcking mofo");
		currentTarget = obj;
	}
	
}
