using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBomba : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter2D(Collider2D collider)
	{

		if ((collider.transform.position.x == FindObjectOfType<Sabie>().transform.position.x)
			&& (collider.transform.position.y == FindObjectOfType<Sabie>().transform.position.y))
			FindObjectOfType<AdministratorJoc>().AtinsBomba();
		else
			return;
	}
}
