using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour {
	public GameObject Luz;

	// Use this for initialization
	void Start () {
		AcendeLuz();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AcendeLuz()
	{
		Luz.SetActive(true);
		Invoke("ApagaLuz", Random.Range(0.5f,2));
	}

	void ApagaLuz()
	{
		Luz.SetActive(false);
		Invoke("AcendeLuz", Random.Range(0.2f,1));
	}

	public void Play()
	{
		SceneManager.LoadScene("Level0");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
