using UnityEngine;
using System.Collections;

public class RockFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		Debug.Log(collision.collider.gameObject.name);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log(other.name);
	}
}
