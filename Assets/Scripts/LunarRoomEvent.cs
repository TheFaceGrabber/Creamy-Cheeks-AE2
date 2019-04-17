using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LunarRoomEvent : MonoBehaviour
{
	public PlayableDirector Cinematic;
	public GameObject Priest;
	GameObject Loui;
	public GameObject LouiWolf;
	
	public GameObject Werewolf;
	
	// Use this for initialization
	public void StartEvent ()
	{
		Loui = GameObject.Find("Loui");
		
		StartCoroutine(BeginEvent());
	}

	IEnumerator BeginEvent()
	{
		Loui.SetActive(false);
		LouiWolf.SetActive(true);
		
		Cinematic.Play();
		
		yield return new WaitForSeconds(91);
		
		Priest.SetActive(false);
		GameObject i = Instantiate(Werewolf, Priest.transform.position, Priest.transform.rotation);
	}
}
