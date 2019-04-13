using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    //We choose not to ref the player in case of respawn
    public float rotSpeed = 180f;
    private Transform player;


    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            GameObject target = GameObject.Find("Player");

            if (target)
                player = target.transform;
        }

        //Player is either found or nonexistent


        if (!player)
            return; //Try again next frame

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
