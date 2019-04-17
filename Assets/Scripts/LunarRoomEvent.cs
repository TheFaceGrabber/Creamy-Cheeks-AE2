using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using CreamyCheaks.AI;
using UnityEngine.AI;

public class LunarRoomEvent : MonoBehaviour
{
	public PlayableDirector Cinematic;
    public GameObject MaskedMan;
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
        MaskedMan.SetActive(true);
        Priest.SetActive(true);

        Priest.transform.position = new Vector3(78.25f, -3, 55.25f);
        Priest.transform.eulerAngles = new Vector3(0, 86, 0);

        MaskedMan.transform.position = new Vector3(80, -3, 55.25f);
        MaskedMan.transform.eulerAngles = new Vector3(0, -87, 0);

        Priest.GetComponent<NavMeshAgent>().enabled = false;
        MaskedMan.GetComponent<NavMeshAgent>().enabled = false;

        Priest.GetComponent<FiniteStateMachine>().enabled = false;
        MaskedMan.GetComponent<FiniteStateMachine>().enabled = false;


        Loui.SetActive(false);
		LouiWolf.SetActive(true);
        LouiWolf.GetComponent<NavMeshAgent>().enabled = false;
        LouiWolf.GetComponent<FiniteStateMachine>().enabled = false;

        Cinematic.Play();
		
		yield return new WaitForSeconds(15);

        Cinematic.Stop();

        LouiWolf.GetComponent<FiniteStateMachine>().enabled = true;
        LouiWolf.GetComponent<NavMeshAgent>().enabled = true;

        LouiWolf.GetComponent<WerewolfFSM>().CurrentTarget = Priest.GetComponent<WerewolfTarget>();
    }
}
