using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
    public Door[] doors;
    public Trigger [] EventTriggers;
    public GameObject[] NPCs;
  	// Use this for initialization
	void Awake () {
        //doors = GameObject.FindObjectsOfType<Door>();
        //EventTriggers = GameObject.FindObjectsOfType<Trigger>();
	}

    //private void Start()
    //{
    //    StartCoroutine(Delay());
    //}

    //IEnumerator Delay()
    //{
    //    yield return new WaitForSeconds(0.01f);
    //    SkipLevel();
    //}

    // Update is called once per frame
    void Update () {
		
	}

    public void SkipLevel()
    {
        foreach (Door door in doors) door.PlayerInteract();
        foreach (GameObject npc in NPCs) npc.SetActive(true);
        foreach (Trigger trigger in EventTriggers) trigger.gameObject.SetActive(false) ;
        GameObject.Find("Player").transform.position = new Vector3(8.7f, 7.1f, 65.8f);
    }
}
