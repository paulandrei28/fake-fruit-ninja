using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorFructe : MonoBehaviour {

	public GameObject[] fructdeGenerat;
	public float timpMin = .3f;
	public float timpMax = 1f;
	public int sansaBomba, vitezaMin, vitezaMax;

	public Transform[] generatoare;

	// Use this for initialization
	void Start () {
		StartCoroutine(GenereazaFructe());               //cream alt thread
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator GenereazaFructe()
	{
		while (true)         //loop 
		{
			yield return new WaitForSeconds(Random.Range(timpMin, timpMax)); // asteapta un timp random intre intervalul ales
			Transform t = generatoare[Random.Range(0, generatoare.Length)];        //selectie care generator random

			GameObject go = null;
			float p = Random.Range(0, 100);

			if (p < sansaBomba)
				go = fructdeGenerat[0];
			else
				go = fructdeGenerat[Random.Range(1,fructdeGenerat.Length)];
			
			GameObject fruct = Instantiate(go, t.position, t.rotation);
			fruct.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(vitezaMin, vitezaMax)); // aruncare fruct in sus prin aplicare forta


			Destroy(fruct, 4);
		}
		
	}
}
