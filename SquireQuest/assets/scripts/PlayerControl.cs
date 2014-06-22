using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class PlayerControl : MonoBehaviour {

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	public GameObject dragonsR;
	public GameObject dragonsL;

	public GameObject chargeSign;

	private Vector3 moveDirection = Vector3.zero;
	private bool facingRight = true;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();	
	}

	void Update() {

		if ( Input.GetKeyDown("r") ){
			transform.position = new Vector3(22.0f,11.0f,5.0f); 	
		}

		if(Input.GetKey(KeyCode.Space)){
			chargeSign.SetActive(true);
			chargeSign.collider.enabled = true;
		}else{
			chargeSign.SetActive(false);
			chargeSign.collider.enabled = false;
		}

		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetAxis("Vertical") > 0.0f)
				moveDirection.y = jumpSpeed;
			
		}else{
			moveDirection.y -= gravity * Time.deltaTime;
		}

		if( moveDirection.x > 0 && !facingRight ) Flip();
		else if ( moveDirection.x < 0 && facingRight ) Flip ();

		controller.Move(moveDirection * Time.deltaTime);
	}

	void Flip ()  {
		facingRight = !facingRight;
		Vector3 temp_scale = transform.localScale;
		//invert x
		temp_scale.x *= -1.0f;
		transform.localScale = temp_scale;
	}

	void OnTriggerStay(Collider other) {

		string input = other.name;
		Match matchR = Regex.Match(input,"dragonsR");
		if( matchR.Success && Input.GetKeyUp("e")){
			Vector3 temp_pos = other.gameObject.transform.position;
			Destroy(other.gameObject);
			Instantiate(dragonsL, temp_pos, new Quaternion());
		}
		Match matchL = Regex.Match(input,"dragonsL");
		if( matchL.Success && Input.GetKeyUp("e")){
			Vector3 temp_pos = other.gameObject.transform.position;
			Destroy(other.gameObject);
			Instantiate(dragonsR, temp_pos, new Quaternion());
		}
	}

	void OnCollisionEnter(Collision col){
		//Debug.Log(col.collider.name);
	}

	void OnTriggerEnter(Collider other){
		//sDebug.Log(other.name);
	}
}
