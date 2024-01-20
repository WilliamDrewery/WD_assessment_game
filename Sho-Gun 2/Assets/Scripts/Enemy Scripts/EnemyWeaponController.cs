using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    public GameObject Weapon;
    public Transform Enemy;
    public Transform EnemyBullet;
    private GameObject PlayerGO;
    public GameObject RoomTrigger;
    public float CurrentFrame = 3f;
    public float ShootTime = 4f;
    public float BulletSpeed = 3f;
    

    
    void Update()
    {
        if (RoomTrigger.GetComponent<TriggerController>().PlayerPresence == true)
        {
            PlayerGO = FindObjectOfType<PlayerController>().gameObject;
            Vector2 position = transform.position;
            Vector2 player = PlayerGO.transform.position;
            float angle = AngleBetweenTwoPoints(position, player);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 180));

            Weapon.transform.SetParent(Enemy.transform);



            CurrentFrame += Time.deltaTime;
            if (CurrentFrame >= ShootTime)
            {

                Instantiate(EnemyBullet, Weapon.transform.position, Quaternion.identity);
                CurrentFrame = Random.Range(0f,2.5f);
            }
        }
        
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    
}
