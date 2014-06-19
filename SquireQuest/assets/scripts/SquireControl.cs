using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class SquireControl : MonoBehaviour {

	public Camera squireCam;
	public Camera knightCam;

	public float maxSpeed = 10.0f;
	public float jumpSpeed = 3000.0f;

	bool facingRight = true;

	bool grounded = true;



	public GameObject bridge;
	public GameObject dragonsR;
	public GameObject dragonsL;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

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
		if( Input.GetKeyDown (KeyCode.LeftShift)){
			squireCam.enabled = false;
			knightCam.enabled = true;
		}
		if ( Input.GetKeyUp (KeyCode.LeftShift)){
			squireCam.enabled = true;
			knightCam.enabled = false;	
		}
		if ( Input.GetKeyDown("r") ){
			rigidbody2D.position = new Vector3(22.0f,11.0f,0.0f); 	
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


		string tag = collision.collider.tag;

		//if(collision.collider.transform.parent.name.Equals("Level");
		if(!grounded && tag.Equals("Ground")){
			grounded = true;
		}

		if( input.Equals("Bridge") ){
			Instantiate(bridge, new Vector3(51.0f, 4.0f, 0.0f), new Quaternion());
		}





	}

	void OnCollisionStay2D(Collision2D collision){
		string input = collision.collider.name;
		Match matchR = Regex.Match(input,"dragonsR");
		if( matchR.Success && Input.GetKeyDown("space")){
			Destroy(collision.gameObject);
			Instantiate(dragonsL, new Vector3(rigidbody2D.position.x, (rigidbody2D.position.y + 2.0f), 0.0f), new Quaternion());
		}
		Match matchL = Regex.Match(input,"dragonsL");
		if( matchL.Success && Input.GetKeyDown("space")){
			Destroy(collision.gameObject);
			Instantiate(dragonsR, new Vector3(rigidbody2D.position.x, (rigidbody2D.position.y + 2.0f), 0.0f), new Quaternion());
		}
	}
}
