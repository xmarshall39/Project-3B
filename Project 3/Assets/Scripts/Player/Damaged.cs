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

    //Vars for exploding the object on death
    public ParticleSystem ps;


    private string type;
    private bool killed = false;
    

    private void Start()
    {
        print("Starting");
        correctLayer = this.gameObject.layer;
        type = this.gameObject.tag;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");
        if(invulnTimer <= 0)
        {
            health--;
            if (type == "Player")
                invulnTimer = 2f;
            else
                invulnTimer = .2f;
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

        if (health <= 0 && !killed)
        {
            print(killed);
            
            ExplodeMe();
        }
    }

    void ExplodeMe()
    {
        killed = true;
        Instantiate(ps, transform.position, transform.rotation);
        Destroy(this.gameObject);
        
    }
}
