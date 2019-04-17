using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToStation : MonoBehaviour
{
    public float turretSpeed = 1.5f;
    Vector3 movePos;

    private void Start()
    {
        //Destination in some radius from spawner transform (origin)
        movePos = Random.onUnitSphere * Random.Range(-6f, 6f);
    }
    void Update()
    {
        //Only move the newly spawned prefabs

        if (this.name == "Turret(Clone)")
        {
            
            print(movePos);
            transform.position = Vector3.MoveTowards
                (transform.position, movePos, turretSpeed * Time.deltaTime);

        }
    }
}
