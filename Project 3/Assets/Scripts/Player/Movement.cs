using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotSpeed = 180f;
    public float shipBoundaryRad = 0.5f;

    private Rigidbody2D rb;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Gather player input
    void Update()
    {
        //Rotate the Ship
        Quaternion rot = transform.rotation;
        //Change z based on input
        float z = rot.eulerAngles.z;
        z += -Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //Recreate out Quat and assign
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Move the ship
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        pos += rot * velocity;

        //Restrict player to bounds

        // y bounds limited by the camera
        if (pos.y + shipBoundaryRad > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize;
        }

        if (pos.y - shipBoundaryRad < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize;
        }

        //Used for x boundaries which are dynamic to screen ratio
        float screenRatio = (float)Screen.width / (float)Screen.height; 
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if(pos.x + shipBoundaryRad > widthOrtho)
        {
            pos.x = widthOrtho;
        }

        if (pos.x - shipBoundaryRad < -widthOrtho)
        {
            pos.x = -widthOrtho;
        }

        transform.position = pos;

    }


}
