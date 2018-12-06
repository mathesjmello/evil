using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
		Metro.transform.position = Vector3.Lerp(Metro.transform.position, Levelposition[0], Time.deltaTime);
		InvokeRepeating("ChamaMetro", 1,0.01f);
		if (Vector3.Distance(transform.position, Levelposition[0]) < 0.1f)
			CancelInvoke("ChamaMetro");
	}

	public void VazaMetro()
	{
		Metro.transform.position =
			Vector3.Lerp(Metro.transform.position, Levelposition[1], Time.deltaTime);
		InvokeRepeating("VazaMetro", 1,0.01f);
		if (Vector3.Distance(transform.position, Levelposition[1]) < 0.1f)
			CancelInvoke("VazaMetro");
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
}
