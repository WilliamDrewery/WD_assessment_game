using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private GameObject player;
    Rigidbody2D rb;
    float BulletSpeed = 3.5f;
    public GameObject EnemyBullet;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 PlayerDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(PlayerDirection * BulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Walls"))
        {
            Destroy(EnemyBullet);
        }
        else if (collider.CompareTag("Player"))
        {
            Destroy(EnemyBullet);
            
        }
        else if (collider.CompareTag("Obstacles"))
        {
            Destroy(EnemyBullet);
        }

    }


}
