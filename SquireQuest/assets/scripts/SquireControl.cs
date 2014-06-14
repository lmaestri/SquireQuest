using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class SquireControl : MonoBehaviour {

	public float maxSpeed = 10.0f;
	public float jumpSpeed = 3000.0f;

	bool facingRight = true;

	bool grounded = true;



	public GameObject bridge;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
				Flip ();
		else if (move < 0 && facingRight)
				Flip ();

		float jump = Input.GetAxis ("Vertical");
		if( jump > 0 && grounded){
			rigidbody2D.AddForce( transform.up * jumpSpeed );
			grounded = false;
		}

	}

	void Flip() {

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision){
		string input = collision.collider.name;
		Match match1 = Regex.Match(input,"Dirt*");
		Match match2 = Regex.Match(input,"Stone*");
		//if(collision.collider.transform.parent.name.Equals("Level");
		if(!grounded && match1.Success){
			grounded = true;
		}

		if( input.Equals("Bridge") ){
			Instantiate(bridge, new Vector3(51.0f, 4.0f, 0.0f), new Quaternion());
		}

		if( match2.Success){
			Destroy(GameObject.Find("ObstacleRock01"));
		}



	}
}
