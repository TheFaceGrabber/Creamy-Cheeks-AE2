using System.Collections;
using System.Collections.Generic;
using CreamyCheaks.AI;
using UnityEngine;

public class WerewolfTracker : MonoBehaviour {

	Dictionary<string,GameObject> characters = new Dictionary<string, GameObject>();

	// Use this for initialization
	void Start ()
	{
		var chars = GameObject.FindObjectsOfType<FiniteStateMachine>();
		for (int i = 0; i < chars.Length; i++)
		{
			characters.Add(chars[i].name,chars[i].gameObject);
		}
	}

	public bool IsCharacterWerewolf(string name)
	{
		if (!characters.ContainsKey(name)) return false;

		return characters[name].GetComponent<WerewolfTarget>();
	}

	public void UpdateCharacter(string name, GameObject obj)
	{
		if (!characters.ContainsKey(name)) return;

		characters[name] = obj;
	}
}
