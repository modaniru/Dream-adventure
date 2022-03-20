using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionDamage : MonoBehaviour
{

    public int collisionDamage = 1;
    public string collisionTag = "Player";

    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
