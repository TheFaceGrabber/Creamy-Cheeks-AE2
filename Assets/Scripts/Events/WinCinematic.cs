using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Linq;
using UnityEngine.SceneManagement;

public class WinCinematic : MonoBehaviour {

    public Camera cam;
    public PlayableDirector PlayableDirector;
    public GameObject WolfyBoy;
    public GameObject Character;

    public bool TryRunCinematic()
    {
        Debug.Log("TryRunCinematic");

        var list = FindObjectsOfType<CreamyCheaks.AI.WerewolfFSM>().Where(x => x.name == "DEADWOLF").ToList();
        
        if (list.Count >= CreamyCheaks.AI.WerewolfFSM.CurrentWerewolfCount)
            return false;

        StartCoroutine("RunEndCinematic");

        return true;
    }

    IEnumerator RunEndCinematic()
    {
        print("End");
        yield return new WaitForSeconds(3);
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player)
            player.SetActive(false);

        WolfyBoy.SetActive(true);
        Character.SetActive(true);
        cam.gameObject.SetActive(true);
        PlayableDirector.Play();

        yield return new WaitForSeconds(11);


        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
