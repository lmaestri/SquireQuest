using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class SirKnight_KI : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject rock;
	public GameObject wood;

	bool facingRight = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 pos = rigidbody2D.position;
		if (pos.x < 665)
			if (speed > rigidbody2D.velocity.x)
				rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
			else
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);
		//resets on death
		if (pos.x > 282 && pos.y > (-80) && pos.y < (-65))
			rigidbody2D.position = new Vector2 (146f, -24f);
		if (pos.x < 282 && pos.y < (-233))
			rigidbody2D.position = new Vector2 (93f, -115f);
		if (pos.x > 282 && pos.y < (-233)) {
			rigidbody2D.position = new Vector2 (298f, -205f);
			rock.rigidbody2D.position = new Vector2(526.1115f, -88.02936f);
			rock.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
			rock.rigidbody2D.angularVelocity = 0.0f;
			rock.rigidbody2D.rotation = 0.0f;
			wood.rigidbody2D.position = new Vector2(528.4794f, -210.829f);
			wood.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
			wood.rigidbody2D.angularVelocity = 0.0f;
			wood.rigidbody2D.rotation = 0.0f;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		string input = collision.collider.name;
		Match matchR = Regex.Match(input,"dragonsR");
		Match matchL = Regex.Match(input,"dragonsL");
		
		if(matchR.Success){
			if (!facingRight){
				Flip ();
				speed = -speed;
			}
		}
		if(matchL.Success){
			if (facingRight){
				Flip ();
				speed = -speed;
			}
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
