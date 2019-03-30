using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfTarget : MonoBehaviour
{
    public GameObject Werewolf;
    
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
                Debug.Log("Went full tranny");
                //Change to werewolf
                if (gameObject.CompareTag("Player"))
                {
                    //Do Player
                }
                else
                {
                    Instantiate(Werewolf, transform.position, transform.rotation);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
