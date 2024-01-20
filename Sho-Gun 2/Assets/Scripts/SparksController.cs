using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksController : MonoBehaviour
{
    public GameObject sparks;
    void Awake()
    {
        Sparks();
    }

    // Update is called once per frame
    IEnumerator Sparks()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }
    
}
