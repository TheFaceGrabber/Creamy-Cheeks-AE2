using System.Collections;
using System.Collections.Generic;
using CreamyCheaks.Input;
using UnityEngine;
using CreamyCheaks.AI;
using UnityEngine.AI;

public class Gun : Item {
    public int BulletCount;
    public float ShootDistance;
    public LayerMask WhatCanShoot;
    public bool UsingSilverBullets;

    public AudioClip Sound;

    SfxPlayer Sfx; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.green);
        if (InputManager.GetButtonDown("Attack"))
        {
            Fire();
        }
    }


    public virtual void Fire()
    {
        //TODO Add bullets
        //if (BulletCount > 0)
        // {
        if (!Sfx)
            Sfx = GameObject.Find("SfxPlayer").GetComponent<SfxPlayer>();

        Sfx.PlaySfx(Sound);
        BulletCount--;
        print("Shot");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, ShootDistance, WhatCanShoot))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red, 5);
            if (hit.transform.gameObject.CompareTag("NPC"))
            {
                //damage them for however much
                print("Hit NPC");
            }

            if (hit.transform.gameObject.CompareTag("Werewolf"))
            {
                //if silver bullets kill
                print("Hit Werewolf");

                hit.transform.gameObject.name = "DEADWOLF";

                hit.transform.GetComponent<CreamyCheaks.AI.WerewolfFSM>().isAlive = false;
                hit.transform.GetComponent<NavMeshAgent>().enabled = false;

                hit.transform.GetComponent<Animator>().ResetTrigger("Death");
                hit.transform.GetComponent<Animator>().SetTrigger("Death");


                var go = GameObject.Find("Win Cinematic");
                go.GetComponent<WinCinematic>().TryRunCinematic();
            }

        }
        //}

    }
}
