using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfAnimationScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsWalking", true);
        } else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", true);
           
        } else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Death");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Roar");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
        }
	}
}
