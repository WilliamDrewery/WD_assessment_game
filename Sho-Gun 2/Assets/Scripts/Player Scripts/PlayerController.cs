using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] TextMeshProUGUI healthText;
    Animator anim;
    public int PlayerHealth = 100;
    [SerializeField] GameObject DeathUI;
    [SerializeField] GameObject NormalUI;
    public GameObject weapon;
    bool invincible;
    public float DiveForce=120f;

    public Material BaseMaterial;
    public Material DodgeMaterial;
    SpriteRenderer SpriteRend;
    float DiveCooldown = 40f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DeathUI.SetActive(false);
        Time.timeScale = 1.0f;
        invincible = false;

        SpriteRend = GetComponent<SpriteRenderer>();
        BaseMaterial = SpriteRend.material;
    }
    void FixedUpdate()
    {
        float speed = 2.5f;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"),
        Input.GetAxis("Vertical")) * speed;

        if(DiveCooldown > 0) {
            {
                DiveCooldown--;
            } }

        //Vector2 direction = (transform.position - Input.mousePosition).normalized;
        if (Input.GetMouseButton(1))
        {
            if(DiveCooldown == 0)
            {
                StartCoroutine("Dive");
            }
            
        }

    }
    
    void Update()
    {
        if (invincible)
        {
            SpriteRend.material = DodgeMaterial;
        }
        else
        {
            SpriteRend.material = BaseMaterial;
        }



        anim.SetFloat("xSpeed", rb.velocity.x);
        anim.SetFloat("ySpeed", rb.velocity.y);
        if (rb.velocity.magnitude < 0.01)
       {
            anim.speed = 0.0f;
        }

        else
        {
            anim.speed = 1.0f;
        }


        if (PlayerHealth <= 0)
        {
            OnDeath();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invincible)
        {
            if (other.CompareTag("EnemyBullet"))
            {
                PlayerHealth -= 10;
                healthText.text = (PlayerHealth.ToString() + "/100");
            }
            else if (other.CompareTag("Healing"))
            {
                PlayerHealth += 30;
                if (PlayerHealth > 100)
                {
                    PlayerHealth = 100;
                }
                healthText.text = (PlayerHealth.ToString() + "/100");
                Destroy(other.gameObject);
            }
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == ("Enemy"))
            {
                if (collision.gameObject.GetComponent<EnemyController>().alive == true)
                {
                    PlayerHealth -= 5;
                    healthText.text = (PlayerHealth.ToString() + "/100");
                }
                
            }

        }
        
    }
    void OnDeath()
    {
        transform.rotation = (Quaternion.Euler(new Vector3(0f, 0f, -90)));
        DeathUI.SetActive(true);
        NormalUI.SetActive(false);
        Time.timeScale = 0;
        weapon.SetActive(false);
    }

    public IEnumerator Dive()
    {
        invincible = true;


        transform.position += weapon.GetComponent<WeaponController>().transform.right * DiveForce * Time.deltaTime * 3;
        DiveCooldown = 40f;
        yield return new WaitForSeconds(0.5f);

        invincible = false;
        
    }
}
