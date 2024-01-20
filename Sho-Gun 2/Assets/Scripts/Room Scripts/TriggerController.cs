using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public bool PlayerPresence;
    public bool EnemyPresence;

    private void Start()
    {
        PlayerPresence = false;
        EnemyPresence = true;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerPresence=true;
        }
        if (collider.CompareTag("Enemy"))
        {
            EnemyPresence = true;
        }
        
    }



}
