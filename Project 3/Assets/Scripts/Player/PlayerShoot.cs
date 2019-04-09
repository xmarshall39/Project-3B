using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Fire Rate")]
    public Vector3 laserOffset = new Vector3(0, 0.5f, 0);

    public GameObject laserPrefab;
    // We keep the layer for security purposes
    private int laserLayer;

    public float fireDelay = 0.25f;
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
    }
}
