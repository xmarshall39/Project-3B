using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject gameObject;
    public ParticleSystem ps;
    private string player_type;
    private ParticleSystem.EmissionModule em;

    // Start is called before the first frame update
    void Start()
    {
        em = ps.emission;
        em.enabled = false;


        player_type = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        //Creates an explosion when the gameobject dies
        if (!gameObject)
        {
            em.enabled = true;
        }
    }
}
