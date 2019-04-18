using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndCinematic : MonoBehaviour {

    public Camera cam;
    public PlayableDirector PlayableDirector;
    public GameObject WolfyBoy;

    public bool TryRunCinematic()
    {
        var list = FindObjectsOfType<WerewolfTarget>();
        if (list.Length > 0)
            return false;

        StartCoroutine("RunEndCinematic");

        return true;
    }

    IEnumerator RunEndCinematic()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player)
            player.SetActive(false);

        WolfyBoy.SetActive(true);
        cam.gameObject.SetActive(true);
        PlayableDirector.Play();

        yield return new WaitForSeconds(19.5f);


        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
