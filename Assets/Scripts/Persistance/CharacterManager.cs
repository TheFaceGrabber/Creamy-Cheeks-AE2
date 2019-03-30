using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CreamyCheaks.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
	public string[] AllScenes;
	
	public List<CharacterHolder> Characters = new List<CharacterHolder>();
	
	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < Characters.Count; i++)
		{
			SceneManager.MoveGameObjectToScene(Characters[i].Character, SceneManager.GetSceneByName(Characters[i].CurrentScene)); //Move all characters into Utility scene
		}
	}
	
	public bool LoadScene(string scene, string unloadScene = "")
	{
		if (!AllScenes.Contains(scene))
		{
			Debug.Log(scene + " could not be found in \"AllScenes\"... returning");
			return false;
		}

		if (!string.IsNullOrEmpty(unloadScene))
		{
			if (AllScenes.Contains(unloadScene))
			{
				Debug.Log(unloadScene + " could not be found in \"AllScenes\"... skipping unloadScene");

				if (isSceneLoaded(unloadScene))
				{
					var unloadChars = Characters.Where(x => x.CurrentScene == unloadScene).ToList();
					for (int i = 0; i < unloadChars.Count; i++)
					{
						//Disable any characters that are in the scene to unload
						Characters[i].Character.SetActive(false);
					}

					SceneManager.UnloadSceneAsync(unloadScene);
				}
			}
		}

		if (!isSceneLoaded(scene))
		{
			var loadChars = Characters.Where(x => x.CurrentScene == scene).ToList();
			for (int i = 0; i < loadChars.Count; i++)
			{
				//Enable all characters that are in the scene to unload
				Characters[i].Character.SetActive(true);
			}

			SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
		}

		return true;
	}

	bool isSceneLoaded(string scene)
	{
		bool final = false;
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			var s = SceneManager.GetSceneAt(i);
			if (s.name == scene)
				final = true;
		}

		return final;
	}
}

[System.Serializable]
public class CharacterHolder
{
	public GameObject Character;
	public string CurrentScene;
	public bool IsPlayer = false;
}
