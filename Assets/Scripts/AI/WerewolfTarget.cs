﻿using System.Collections;
using System.Collections.Generic;
using CreamyCheaks.PlayerController;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WerewolfTarget : MonoBehaviour
{
    [Header("For NPCs")]
    public GameObject Werewolf;

    [Header("For Player")] public PostProcessVolume postLayer;
    public PostProcessProfile WerewolfProfile;
    public GameObject HumanModel;
    public GameObject WerewolfModel;
    
    private rpgStats stats;
    private float chanceToChange = .25f;
    
    private void Start()
    {
        stats = GetComponent<rpgStats>();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " took damage");
        stats.Health.Add(damage);
        if (stats.Health.GetValue() > 0)
        {
            float ran = Random.value;
            if (ran < chanceToChange)
            {
                //Change to werewolf
                if (gameObject.CompareTag("Player"))
                {
                    //TODO convert Player
                    postLayer.profile = WerewolfProfile;
                    GameObject.Find("InventoryManager").SetActive(false);
                    HumanModel.SetActive(false);
                    WerewolfModel.SetActive(true);
                    GetComponent<PlayerController>().SetIsWerewolf(true);
                    Destroy(this);
                }
                else
                {
                    Instantiate(Werewolf, transform.position, transform.rotation);
                    Destroy(this);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
