using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DoorController : MonoBehaviour
{
    public GameObject DoorLeft;
    public GameObject DoorRight;
    public GameObject RoomTrigger;
    public GameObject self;
    [SerializeField] TextMeshProUGUI ScoreTMP;

    void Start()
    {
       
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Destroy(self);
        }
    }
}
