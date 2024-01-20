using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float followSpeed;
    public GameObject Weapon;
    public Transform Player;
    public GameObject PlayerGO;
    public Transform Bullet;
    public Transform firepos;
    public Vector3 direction;
    private SpriteRenderer WeaponSR;
    public float cooldown=10f;

    void Update()
    {
        Vector2 position = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouse = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(position, mouse);
        Vector3 scale=transform.localScale;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 180));

        Weapon.transform.SetParent(Player.transform);
        


        if (Input.GetMouseButtonDown(0))
        {
            if(cooldown == 0)
            {
                direction = (mouse - position).normalized;
                Transform bulletTransform = Instantiate(Bullet, Player.position, Quaternion.identity);
                
                bulletTransform.GetComponent<PlayerBulletController>().Direction(direction);
                cooldown = 20f;
            }
            
        }


        if (PlayerGO.GetComponent<PlayerController>().rb.velocity.y > 0 && PlayerGO.GetComponent<PlayerController>().rb.velocity.x<0.5 && PlayerGO.GetComponent<PlayerController>().rb.velocity.x > -0.5)
        {
            WeaponSR=GetComponent<SpriteRenderer>();
            WeaponSR.sortingOrder = 1;
        }
        else
        {
            WeaponSR=GetComponent<SpriteRenderer>();
            WeaponSR.sortingOrder = 3;
        }
    }
    private void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
