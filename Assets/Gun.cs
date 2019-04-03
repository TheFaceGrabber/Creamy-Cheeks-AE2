using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item {
    public int BulletCount;
    public float ShootDistance;
    public LayerMask WhatCanShoot;
    public bool UsingSilverBullets;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.green);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }


    public virtual void Fire()
    {
        if (BulletCount > 0)
        {
            BulletCount--;
            print("Shot");

           RaycastHit hit;
              if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, ShootDistance, WhatCanShoot))
            {
                if (hit.transform.gameObject.CompareTag("NPC"))
                {
                    //damage them for however much
                        print("Hit NPC");
                }

                if (hit.transform.gameObject.CompareTag("Werewolf"))
                {
                    //if silver bullets kill
                    print("Hit Werewolf");
                }
               
            }
        }
            
    }
}
