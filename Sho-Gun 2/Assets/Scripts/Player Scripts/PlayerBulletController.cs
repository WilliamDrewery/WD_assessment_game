using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private Vector3 direction;
    public GameObject bullet;
    public float knockbackForce=1f;
    public EnemyController enemyController;
    GameObject GM;
    GameManagerController GMC;
    int score;
    Rigidbody2D enemyRB;
    public void Direction(Vector3 direction)
    {
        this.direction = direction;
    }
    void Update()
    {
        float speed = 10f;
        transform.position += direction * speed * Time.deltaTime;

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag ("Walls"))
        {
            Destroy(bullet);
        }
        else if (collider.CompareTag("Enemy"))
        {
            Destroy(bullet);
            if(collider.GetComponent<EnemyController>().alive)
            {
                collider.GetComponent<EnemyController>().enabled = false;
                enemyRB= collider.GetComponent<Rigidbody2D>();
                Vector2 directionEnemy = (collider.transform.position - transform.position).normalized;
                Vector2 knockback = directionEnemy * knockbackForce;
                enemyRB.velocity = Vector2.zero;
                enemyRB.AddForce(knockback, ForceMode2D.Impulse);
                wait();
                collider.GetComponent<EnemyController>().enabled = true;

                collider.GetComponent<EnemyController>().Health--;
            }
            else if (collider.GetComponent<EnemyController>().alive==false)
            {

                
                enemyRB=collider.GetComponent<Rigidbody2D> ();
                enemyRB.isKinematic = false;
            }
            


        }
        else if (collider.CompareTag("Obstacles"))
        {
            Destroy(bullet);
        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
