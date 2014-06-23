using UnityEngine;
using System.Collections;

public class RockFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0.0f, -1000.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		Debug.Log(collision.collider.gameObject.name +"collision");
	}

	void OnTriggerEnter(Collider other){
		Debug.Log(other.name + "trigger");
	}
}
