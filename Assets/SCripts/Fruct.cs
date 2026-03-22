using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruct : MonoBehaviour {


	public GameObject fructTaiat; //stocare obiect aici

	public void CreeazaFructTaiat()
	{
		GameObject obiectul = (GameObject)Instantiate(fructTaiat, transform.position, transform.rotation);  //creare la aceeasi pozitie si rotatie
        Rigidbody[] rigBody = obiectul.transform.GetComponentsInChildren<Rigidbody>(); //luare componente rigidbody din obiect
		foreach(Rigidbody r in rigBody)
        {
			r.transform.rotation = Random.rotation;
			r.AddExplosionForce(Random.Range(300, 2000), transform.position, Random.Range(2, 10));
        }
		FindObjectOfType<AdministratorJoc>().incrementeazaScor();
		Destroy(gameObject); //distrugere fruct netaiat
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKeyDown(KeyCode.Space))
        {
			CreeazaFructTaiat();
        }
		*/

	}

	private void OnTriggerEnter2D(Collider2D collider)
    {
		/*
		Sabie sabie = collider.GetComponent<Sabie>();
        if (!sabie)
        {
			return;
        }
		*/
		if((collider.transform.position.x == FindObjectOfType<Sabie>().getCoordx())
			&&(collider.transform.position.y == FindObjectOfType<Sabie>().getCoordy()))
		CreeazaFructTaiat();

	}

	
}
