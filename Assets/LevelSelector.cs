using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
    public GameLauncher GL;
    public Text LevelName;
    public Image LevelImage;
    public Sprite GroundFloor;
    public Sprite UpperFloor;
    public Sprite Basement;
    public Sprite Climax;
    private int CurrentSelection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectNext()
    {
        CurrentSelection++;
        if (CurrentSelection > 2) CurrentSelection = 0;
        UpdateInfo();
    }

    public void SelectPrevious()
    {
        CurrentSelection--;
        if (CurrentSelection < 0) CurrentSelection = 2;
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        switch (CurrentSelection)
        {
            case (0):
                LevelName.text = "Ground Floor";
               LevelImage.sprite = GroundFloor;
                break;

            case (1):
                LevelName.text = "Upper Floor";
                LevelImage.sprite = UpperFloor;
                break;

            case (2):
                LevelName.text = "Basement";
                LevelImage.sprite = Basement;
                break;

            case (3):
                LevelName.text = "Climax";
               // LevelImage.sprite = Climax;
                break;

        };

    }

    public void LoadLevel()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(Destructor());
    }


    IEnumerator Destructor()
    {
        GL.GameStart();
        GL.ToggleLevelSelect();
        yield return new WaitForSeconds(1.4f);
        if (CurrentSelection >= 1) GameObject.Find("GroundFloorCompleter").GetComponent<LevelLoader>().SkipLevel();
        yield return new WaitForSeconds(0);
        if (CurrentSelection >= 2) GameObject.Find("UpperFloorCompleter").GetComponent<LevelLoader>().SkipLevel();
        //if (CurrentSelection == 3) GameObject.Find("BasementCompleter").GetComponent<LevelLoader>().SkipLevel();
        
        
        //switch (CurrentSelection)
        //{
        //    case (3): //skip basement
                
        //    case (2): //skip upper floor

        //    case (1)://skip ground floor
        //        GameObject.Find("GroundFloorCompleter").GetComponent<LevelLoader>().SkipLevel();
        //        break;

        //};


        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
