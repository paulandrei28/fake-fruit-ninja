using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabie : MonoBehaviour {

	public Rigidbody2D rigidbody;
	public Vector3 pozitieMouse;

	public CircleCollider2D colider;
	// Use this for initialization
	//cand e activ obiectul
	void Awake () {
		rigidbody = GetComponent<Rigidbody2D>();
		colider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Input.mousePosition; //coord mouse
		mousePos.z = 15;

		rigidbody.position = Camera.main.ScreenToWorldPoint(mousePos); //permite punerea mouse-ului relativ la scena afisata

		colider.enabled = CursorInMiscare();
	}

	public float getCoordx()
    {
		return rigidbody.position.x;
    }

	public float getCoordy()
	{
		return rigidbody.position.y;
	}

	public bool CursorInMiscare()
    {
		Vector3 pozitiaCurenta = transform.position;
		float deplasare = (pozitieMouse - pozitiaCurenta).magnitude;

		pozitieMouse = pozitiaCurenta;

		if (deplasare > 0)
			return true;
		else
			return false;
    }


}
