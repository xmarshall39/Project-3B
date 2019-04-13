using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnSight : MonoBehaviour
{
    public Vector3 laserOffset = new Vector3(0, 0.5f, 0);
    public GameObject laserPrefab;
    public float fireDelay = 1f;

    private float cooldownTimer = 0f;
    private LineOfSight LOS;
    private int laserLayer;

    // Start is called before the first frame update
    void Start()
    {
      
        laserLayer = gameObject.layer;
        LOS = GetComponent<LineOfSight>();
    }

    // Update is called once per frame
    void Update()
    {

        if(LOS.collision && cooldownTimer <= 0)
        {
            Vector3 offset = transform.rotation * laserOffset;

            GameObject laserGO = Instantiate(laserPrefab, transform.position + offset, transform.rotation);
            laserGO.layer = laserLayer;

            cooldownTimer = fireDelay;
        }

        cooldownTimer -= Time.deltaTime;
    }
}
