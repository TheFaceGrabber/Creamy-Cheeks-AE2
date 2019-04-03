using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWorldItem : Item {
    private GameObject PlayerGun;
	// Use this for initialization
	void Start () {
        GameObject.Find("CarryObject").transform.GetChild(0).gameObject.SetActive(true);
        PlayerGun = GameObject.Find("CarryObject").transform.GetChild(0).gameObject;
        GameObject.Find("CarryObject").transform.GetChild(0).gameObject.SetActive(false);
        print("GotGun");
        print(PlayerGun.name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void PlayerInteract()
    {

        if (ItemPickedUp())
        {
            this.gameObject.SetActive(false);
        }

    }

    public override void ItemUsed() //when player clicks use on item fill info here
    {
        PlayerGun.SetActive(!PlayerGun.activeInHierarchy);
    }
}
