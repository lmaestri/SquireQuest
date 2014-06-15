using UnityEngine;
using System.Collections;

public class KnightIcon : MonoBehaviour {

	public GameObject knight;
	public GameObject player;
	public float icon_distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 kpos = knight.transform.position;
		Vector3 ppos = player.transform.position;

		Vector3 iconpos = kpos - ppos;
		iconpos.Normalize();

		transform.position = player.transform.position + iconpos * icon_distance;

	}
}
