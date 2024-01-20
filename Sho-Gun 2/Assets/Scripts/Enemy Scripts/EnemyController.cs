using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D EnemyRB;
    float directionChangeTimer = 30;
    public GameObject self;
    public Transform EnemyBullet;
    public GameObject Weapon;
    public GameObject player;
    public float Health = 5;
    public bool alive = true;
    public  Material BaseMaterial;
    public Material FlashMaterial;
    SpriteRenderer EnemySpriteR;
    public GameObject BloodSpray;
    float repeat = 1;
    public GameObject RoomTrigger;
   

    void Start()
    {
       
        EnemyRB = GetComponent<Rigidbody2D>();

        EnemySpriteR = GetComponent<SpriteRenderer>();
        BaseMaterial = EnemySpriteR.material;


    }
    

    void FixedUpdate()
    {
        if (Health == 0)
        {
            alive = false;
            transform.rotation = (Quaternion.Euler(new Vector3(0f, 0f, -90)));
            Weapon.GetComponent<EnemyWeaponController>().enabled = false;
            EnemyRB.velocity = Vector3.zero;
            if (repeat == 1)
            {
                Instantiate(BloodSpray, transform.position, Quaternion.identity);
                FindObjectOfType<GameManagerController>().score += 100;




                repeat--;
            }
            
        }
        if (alive)
        {
            if (RoomTrigger.GetComponent<TriggerController>().PlayerPresence == true)
            {
                float direction = Random.Range(0, 5);
                //0=left, 1=up, 2=down, 3=right, 4=still
                if (directionChangeTimer > 0)
                {
                    directionChangeTimer -= 1;
                }
                else if (directionChangeTimer == 0)
                {
                    if (direction == 0)
                    {
                        EnemyRB.velocity = new Vector2(-1, 0);
                    }
                    else if (direction == 1)
                    {
                        EnemyRB.velocity = new Vector2(0, 1);
                    }
                    else if (direction == 2)
                    {
                        EnemyRB.velocity = new Vector2(0, -1);
                    }
                    else if (direction == 3)
                    {
                        EnemyRB.velocity = new Vector2(1, 0);
                    }
                    else
                    {
                        EnemyRB.velocity = new Vector2(0, 0);
                    }
                    directionChangeTimer = 30;
                }
            }
            
        }

        
        
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            if (alive)
            {
                EnemySpriteR.material = FlashMaterial;
                Invoke("UnFlash", 0.1f);
            }
            
            
        }
    }
    void UnFlash()
    {
        EnemySpriteR.material = BaseMaterial;
    }

}
