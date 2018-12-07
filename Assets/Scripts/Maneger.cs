using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maneger : MonoBehaviour
{

	public List<GameObject> Ligths;
	public List<GameObject> ZombiSpans1;
	public GameObject ZombiPrefab;
	public Button Elevador, BotaoElevador, BotaoMetro;
	public GameObject Metro;
	public Vector3[] Levelposition;
	public GameObject PlayerPrefab;
	public GameObject TelaEnd;

	public void OnLights()
	{
		foreach (var objs in Ligths)
		{
			objs.SetActive(true);
		}
		BotaoElevador.interactable = true;
		BotaoMetro.interactable = true;
		ReliseZombis();
	}

	public void ChamaMetro()
	{
		
		InvokeRepeating("AndaMetro", 1,0.01f);
		
	}

	public void VazaMetro()
	{
		InvokeRepeating("SomeMetro", 1,0.01f);
	}

	public void ReliseZombis()
	{
		foreach (var spam in ZombiSpans1)
		{
			var zomb = (GameObject) Instantiate(ZombiPrefab, spam.transform.position, Quaternion.identity);
			zomb.GetComponent<IAcontrol>().gotoposition = PlayerPrefab;
			
		}
	}

	public void AtivaElevador()
	{
		Elevador.interactable = true;
		ReliseZombis();
	}

	private void AndaMetro()
	{
		Metro.transform.position = Vector3.Lerp(Metro.transform.position, Levelposition[0], Time.deltaTime);
		if (Vector3.Distance(transform.position, Levelposition[0]) < 0.1f)
			CancelInvoke("AndaMetro");
	}
	private void SomeMetro()
	{
		Metro.transform.position = Vector3.Lerp(Metro.transform.position, Levelposition[1], Time.deltaTime);
		if (Vector3.Distance(transform.position, Levelposition[1]) < 0.1f)
		{
			CancelInvoke("SomeMetro");
			Invoke("EndGame",0.2f);
		}
			
	}

	public void ReloadScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

	public void Quit()
	{
		Application.Quit();
	}

	void EndGame()
	{
		TelaEnd.SetActive(true);
	}
	
}
