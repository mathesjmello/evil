using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maneger : MonoBehaviour
{

	public List<GameObject> Ligths;
	public List<GameObject> ZombiSpans1;
	public GameObject ZombiPrefab;
	public Button Elevador, BotaoElevador, BotaoMetro;
	public GameObject Metro;
	public Vector3[] Levelposition;

	public void OnLights()
	{
		foreach (var objs in Ligths)
		{
			objs.SetActive(true);
		}
		foreach (var spam in ZombiSpans1)
		{
			Instantiate(ZombiPrefab, spam.transform);
		}
		BotaoElevador.interactable = true;
		BotaoMetro.interactable = true;
		ReliseZombis();
	}

	public void ChamaMetro(int Level)
	{
		Metro.transform.position =
			Vector3.Lerp(Metro.transform.position, Levelposition[Level], Time.deltaTime);
		ReliseZombis();
	}

	public void VazaMetro(int Level)
	{
		Metro.transform.position =
			Vector3.Lerp(Metro.transform.position, Levelposition[Level], Time.deltaTime);
	}

	public void ReliseZombis()
	{
		foreach (var spam in ZombiSpans1)
		{
			Instantiate(ZombiPrefab, spam.transform);
		}
	}

	public void AtivaElevador()
	{
		Elevador.interactable = true;
		ReliseZombis();
	}
}
