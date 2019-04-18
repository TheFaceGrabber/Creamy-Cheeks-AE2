using System.Collections;
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
                    var obj = Instantiate(Werewolf, transform.position, transform.rotation);
                    
                    GameObject.Find("Character Manager").GetComponent<WerewolfTracker>().UpdateCharacter(name,obj);

                    Destroy(gameObject);
                    gameObject.SetActive(false);
                }

                var go = GameObject.Find("Ending Cinematic");
                go.GetComponent<EndCinematic>().TryRunCinematic();
            }
        }
    }
}
