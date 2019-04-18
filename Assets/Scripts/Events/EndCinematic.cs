using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using System.Linq;

public class EndCinematic : MonoBehaviour {

    public Camera cam;
    public PlayableDirector PlayableDirector;
    public GameObject WolfyBoy;

    public bool TryRunCinematic()
    {
        Debug.Log("TryRunCinematic");

        var list = FindObjectsOfType<WerewolfTarget>().ToList();
        list.ForEach(x =>
        {
            if (!x.gameObject.activeInHierarchy || x.enabled == false)
                list.Remove(x);
        });

        if (list.Count > 0)
            return false;

        StartCoroutine("RunEndCinematic");

        return true;
    }

    IEnumerator RunEndCinematic()
    {
        yield return new WaitForSeconds(3);
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
