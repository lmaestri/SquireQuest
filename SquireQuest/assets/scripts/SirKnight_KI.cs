using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class SirKnight_KI : MonoBehaviour {


	public float gravity = 20.0f;
	public float startSpeed = 10.0f;
	public float chargeSpeed = 80.0f;
	public float chargeDuration = 1.0f;

	public GameObject rock;
	public GameObject wood;

	private bool isCharging = false;
	private bool facingRight = true;
	private Vector3 moveDirection  = Vector3.zero;
	private float speed;
	private float chargeStartTime;

	private CharacterController controller;




	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		speed = startSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		CheckForCharge();



		if(isCharging && (Time.time - chargeStartTime) > chargeDuration){
			StopCharge();
			Debug.Log ("Check");
		}

		Vector2 pos = transform.position;

		if (pos.x < 665){
			/*if (speed > controller.velocity.x){
				moveDirection = new Vector3(speed, controller.velocity.y);
				//controller.Move(new Vector3(speed, controller.velocity.y)*Time.deltaTime);
			}else{
				moveDirection = new Vector3(controller.velocity.x, controller.velocity.y);
				//controller.Move (new Vector3(controller.velocity.x, controller.velocity.y)*Time.deltaTime);
			}*/

			moveDirection = new Vector3(speed, controller.velocity.y);

		}
		//resets on death
		if (pos.x > 282 && pos.y > (-80) && pos.y < (-65))
			transform.position = new Vector2 (146f, -24f);
		if (pos.x < 282 && pos.y < (-233))
			transform.position = new Vector2 (93f, -115f);
		if (pos.x > 282 && pos.y < (-233)) {
			transform.position = new Vector2 (298f, -205f);
			rock.rigidbody2D.position = new Vector2(526.1115f, -88.02936f);
			rock.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
			rock.rigidbody2D.angularVelocity = 0.0f;
			rock.rigidbody2D.rotation = 0.0f;
			wood.rigidbody2D.position = new Vector2(528.4794f, -210.829f);
			wood.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
			wood.rigidbody2D.angularVelocity = 0.0f;
			wood.rigidbody2D.rotation = 0.0f;
		}
		//Apply gravity
		if(!controller.isGrounded){
			moveDirection.y -= gravity * Time.deltaTime;
		}
		controller.Move(moveDirection*Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision){
		string input = collision.collider.name;
		Match matchR = Regex.Match(input,"dragonsR");
		Match matchL = Regex.Match(input,"dragonsL");
		
		if(matchR.Success){
			if (!facingRight){
				Flip ();
				speed = -speed;
			}
		}else if(matchL.Success){
			if (facingRight){
				Flip ();
				speed = -speed;
			}
		}
	}

	void CheckForCharge() {
		float distance = 100.0f;
		Vector3 pos = transform.position;
		Vector3 lookAt = transform.position + Vector3.forward * distance;
		Debug.DrawLine(pos, lookAt);
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void StartCharge(){
		if(!isCharging){
			speed = chargeSpeed;
			chargeStartTime = Time.time;
			isCharging = true;

		}
	}

	public void StopCharge(){
		if(isCharging){
			speed = startSpeed;
			isCharging = false;
		}
	}
}
