using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    /*
     Leah Bernstein
     This class handles the movement of the enemy objects, including changing position as the frames go by and the bouncing on the sides of the screen        
         */


    public Camera cam;
    public Vector3 velocity;
    public Vector3 position;

    public float height;
    public float width;

    // Use this for initialization
    void Start() {

        cam = Camera.main;
        height = cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update() {
       
        Move();
        Bounce();
        SetTransform();
    }

    /// <summary>
    /// Handles the very basic math of movement
    /// </summary>
    void Move()
    {
        position += velocity;
    }

    /// <summary>
    /// Would theoretically also turn the object, but currently just alters the official position of the object based on the math of Move()
    /// </summary>
    public void SetTransform()
    {
        //transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        transform.position = position;

    }

    /// <summary>
    /// "Bounces" the enemy objects against the sides of the screen so that they stay within the bounds and can be more useful as enemies
    /// </summary>
    void Bounce()
    {
        if (position.x > width)
        {
            velocity.x = -velocity.x;
        }
        else if (position.x < -width)
        {
            velocity.x = -velocity.x;
        }
        if (position.y > height)
        {
            velocity.y = -velocity.y;
        }
        else if (position.y < -height)
        {
            velocity.y = -velocity.y;
        }

    }
}
