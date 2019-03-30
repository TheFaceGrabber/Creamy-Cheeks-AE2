using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOtherLevels : MonoBehaviour {

    void Awake()
    {
        bool canLoadLower = true;
        bool canLoadUpper = true;
        bool canLoadUtil = true;
        bool canLoadCellar = true;

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var s = SceneManager.GetSceneAt(i);
            if(s.name == "GroundFloor")
                canLoadLower = false;

            if (s.name == "UpperFloor")
                canLoadUpper = false;

            if (s.name == "UtillityScene")
                canLoadUtil = false;
            
            if (s.name == "Cellar")
                canLoadCellar = false;
        }

        if(canLoadLower)
            SceneManager.LoadSceneAsync("GroundFloor", LoadSceneMode.Additive);
        if(canLoadUpper)
            SceneManager.LoadSceneAsync("UpperFloor", LoadSceneMode.Additive);
        if (canLoadUtil)
            SceneManager.LoadSceneAsync("UtillityScene", LoadSceneMode.Additive);
        //if (canLoadCellar)
            //SceneManager.LoadSceneAsync("Cellar", LoadSceneMode.Additive);
    }
}
