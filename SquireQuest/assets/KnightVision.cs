using UnityEngine;
using System.Collections;

public class KnightVision : MonoBehaviour {

	public GameObject knight;
	public float chargeFactor = 10.0f;
	private SirKnight_KI ki;

	// Use this for initialization
	void Start () {
		ki = knight.GetComponent<SirKnight_KI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.name.Equals ("Charge")) ki.StartCharge();
	}	

}
