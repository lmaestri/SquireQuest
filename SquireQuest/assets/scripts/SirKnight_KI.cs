using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class SirKnight_KI : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject rock;
	public GameObject sign;

	bool facingRight = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 pos = rigidbody2D.position;
		if (pos.x < 682.74)
			rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
		if (pos.x > 282 && pos.y > (-80) && pos.y < (-65))
			rigidbody2D.position = new Vector2 (146f, -24f);
		if (pos.x < 282 && pos.y < (-233))
			rigidbody2D.position = new Vector2 (93f, -115f);
		if (pos.x > 282 && pos.y < (-233))
			rigidbody2D.position = new Vector2 (298f, -205f);
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
