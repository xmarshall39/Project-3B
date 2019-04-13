using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Laser Position")]
    public Vector3 laserOffset = new Vector3(0, 0.5f, 0);

    public GameObject laserPrefab;

    // We keep the layer for security purposes
    private int laserLayer;

    public float fireDelay = 0.25f;
    public float tfireDelay = 0.60f;
    private float cooldownTimer = 0;

    void Start()
    {
        laserLayer = gameObject.layer;
    }

    
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            // SHOOT!
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * laserOffset;

            GameObject laserGO = Instantiate(laserPrefab, transform.position + offset, transform.rotation);
            laserGO.layer = laserLayer;
        }

        if( Input.GetButton("Fire2") && cooldownTimer <= 0)
        {
            //Shoot the triple laser
            cooldownTimer = tfireDelay;
            
            Vector3 offset = transform.rotation * laserOffset;
            Quaternion rot = transform.rotation;

            GameObject MLaser = Instantiate(laserPrefab, transform.position + offset, transform.rotation);


            rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y +45, transform.rotation.z + 45);
            GameObject RLaser = Instantiate(laserPrefab, transform.position + offset, rot);


            rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z -45);
            GameObject LLaser = Instantiate(laserPrefab, transform.position + offset, rot);

            //Assign Layering
            MLaser.layer = laserLayer; RLaser.layer = laserLayer; LLaser.layer = laserLayer;

        }
    }
}
