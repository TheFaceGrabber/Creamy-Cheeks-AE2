﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MoveableObject {
    private bool willSmash;
    public float SmashForceNeeded;
    private Rigidbody myRigid;
    public GameObject Rubble;
    public AudioClip SmashSfx;
    public bool HasLoot;
    public GameObject Loot;
	// Use this for initialization
	void Start () {
        myRigid = GetComponent<Rigidbody>();
        SetMarker();
        Sfx = GameObject.Find("SfxPlayer").GetComponent<SfxPlayer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (myRigid.velocity.magnitude > SmashForceNeeded)
        {
            willSmash = true;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (willSmash)
        {
            Smash();
        }
    }

    private void Smash()
    {
        if (Sfx != null) Sfx.PlaySfx(SmashSfx, transform.position);
        GetComponent<ObjectBreakReactor>().OnBreak();
        print("Smash");
        if (HasLoot) Instantiate (Loot, transform.position, transform.rotation);
        Instantiate(Rubble, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
