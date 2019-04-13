using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{

    public Transform sightStart, sightEnd;

    public bool needsCollision = true;
    public bool collision = false;



    void Update()
    {
        
        collision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
        //Visual for the line of sight
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (collision == needsCollision)
        { this.transform.localScale = new Vector3((transform.localScale.x == 1) ? -1 : 1, 1, 1); }


    }
}
