using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    [Header("Rep the number of collisions an object can endure")]
    public int health = 1;
    [Header("Invuln only for the player")]
    float invulnTimer = 0;
    int correctLayer;

    private void Start()
    {
        correctLayer = this.gameObject.layer;
    }
    //Collision will never be set off
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");
        if(invulnTimer <= 0)
        {
            health--;
            invulnTimer = 2f;
            //Puts the player on a contactless invuln layer
            this.gameObject.layer = 10;
        }
        

    }

    private void Update()
    {
        invulnTimer -= Time.deltaTime;

        if(invulnTimer <= 0)
        {
            this.gameObject.layer = correctLayer;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
