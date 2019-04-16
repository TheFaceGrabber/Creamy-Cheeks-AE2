using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public GameObject player;
    private rpgStats playerStats;

    private void Awake()
    {
        //Addition by joe
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        playerStats = player.GetComponent<rpgStats>();
    }
    
	public void attackPlayerVal(int damage)
    {
        if (!playerStats.Strength.RollCheck())
        {
            playerStats.Health.Add(-damage);
        }

        Debug.Log("attackPlayer executed");

    }

	public void attackPlayer()
    {
        if (!playerStats.Strength.RollCheck())
        {
            playerStats.Health.Add(-1);
        }

        Debug.Log("attackPlayer executed");

    }
}
