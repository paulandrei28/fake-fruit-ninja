using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdministratorJoc : MonoBehaviour {


	public int scor;
	public Text txtscor;
	public int celmaibunscor;
	public Text celmaibuntxtscor;

	public GameObject panel, panel1, panel2, panel3;

	public bool pauzaPosibila=false;


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && pauzaPosibila)
        {
			Pauza();
        }
		

	}


	public void incrementeazaScor()
    {
		scor += 1;
		txtscor.text = "Scor: " + scor.ToString();
    }

	void Awake()
	{
		panel.SetActive(false);
		panel1.SetActive(true);
		panel2.SetActive(false);
		panel3.SetActive(false);
		Time.timeScale = 0;

		celmaibunscor = PlayerPrefs.GetInt("RecordJocNinjaFruits");
		celmaibuntxtscor.text = "Record: " + celmaibunscor.ToString();

	}

	public void AtinsBomba()

    {
		pauzaPosibila = false;
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("interactiv"))
		{
			Destroy(go);
		}

		panel.SetActive(true);
		panel1.SetActive(false);
		panel2.SetActive(false);
		Time.timeScale = 0;

    }

	public void SeteazaDificultatea() 
	{

		panel.SetActive(false);
		panel1.SetActive(false);
		panel2.SetActive(true);

	}

	public void Pauza()
	{
		Time.timeScale = 0;
		panel3.SetActive(true);

	}
	public void Continua()
	{
		Time.timeScale = 1;
		panel3.SetActive(false);
	}
	public void Usor()
	{
		FindObjectOfType<GeneratorFructe>().sansaBomba = 10;
		FindObjectOfType<GeneratorFructe>().vitezaMin = 800;
		FindObjectOfType<GeneratorFructe>().vitezaMax = 900;
		FindObjectOfType<GeneratorFructe>().timpMin =.7f;
		FindObjectOfType<GeneratorFructe>().timpMax = 1.2f;
		RepornesteJoc();
	}

	public void Normal() 
	{
		FindObjectOfType<GeneratorFructe>().sansaBomba = 20;
		FindObjectOfType<GeneratorFructe>().vitezaMin = 850;
		FindObjectOfType<GeneratorFructe>().vitezaMax = 950;
		FindObjectOfType<GeneratorFructe>().timpMin = .3f;
		FindObjectOfType<GeneratorFructe>().timpMax = 1f;
		RepornesteJoc();
	}
	public void Greu()
	{
		FindObjectOfType<GeneratorFructe>().sansaBomba = 40;
		FindObjectOfType<GeneratorFructe>().vitezaMin = 900;
		FindObjectOfType<GeneratorFructe>().vitezaMax = 1050;
		FindObjectOfType<GeneratorFructe>().timpMin = .3f;
		FindObjectOfType<GeneratorFructe>().timpMax = .8f;
		RepornesteJoc();
	}

	public void RepornesteJoc()
    {

		pauzaPosibila = true;
		if (scor > celmaibunscor)
		{
			celmaibunscor = scor;
			PlayerPrefs.SetInt("RecordJocNinjaFruits", celmaibunscor);
		}
			celmaibuntxtscor.text = "Record: " + celmaibunscor.ToString();

		scor = 0;
		txtscor.text = "Scor: " + scor.ToString();

		Time.timeScale = 1;
		panel.SetActive(false);
		panel1.SetActive(false);
		panel2.SetActive(false);
	}

	public void Exit()
    {
		if (scor > celmaibunscor)
		{
			celmaibunscor = scor;
			PlayerPrefs.SetInt("RecordJocNinjaFruits", celmaibunscor);
		}
		celmaibuntxtscor.text = "Record: " + celmaibunscor.ToString();
		Application.Quit();
    }
}
