using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {
	public float speed;
	public float damage  = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}
	void OnTriggerEnter2D(Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health = collider.gameObject.GetComponent<Health>();
		if(attacker && health){
			health.dealDamage(damage);
			Destroy(gameObject);
		}
		
		
	}
}
