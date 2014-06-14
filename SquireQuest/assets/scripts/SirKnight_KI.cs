using UnityEngine;
using System.Collections;

public class SirKnight_KI : MonoBehaviour {

	float speed = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(speed, 0.0f);
	}
}
