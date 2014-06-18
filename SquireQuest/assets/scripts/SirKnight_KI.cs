using UnityEngine;
using System.Collections;

public class SirKnight_KI : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject rock;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x < 682.74)
			rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
	}
}
