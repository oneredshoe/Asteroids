using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    /*
     Leah Bernstein
     This class is to manage the movement of the player object by tracking the input provided
     by the arrow keys
         */



    public Camera cam;
    public float height;
    public float width;

    public float accelRate;
    public float angleOfRotation;
    public float maxSpeed;
    public float decelRate;
     
    public Vector3 deceleration;
    public Vector3 playerPosition;
    public Vector3 direction;
    public Vector3 velocity;
    public Vector3 acceleration;

	// Use this for initialization
	void Start () {

        height = cam.orthographicSize;
        width = height * cam.aspect;

        playerPosition = new Vector3(0, 0, 0);
        direction = new Vector3(1, 0, 0);
        velocity = new Vector3(0, 0, 0);
        acceleration = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        RotatePlayer();

        Move();

        SetTransform();

        //Debug.Log("Velocity from update: " + velocity);

	}

    /// <summary>
    /// Turns the player visually to match the turned direction of the movement vectors
    /// </summary>
    public void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angleOfRotation += 2;
            direction = Quaternion.Euler(0, 0, 2) * direction;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angleOfRotation -= 2;
            direction = Quaternion.Euler(0, 0, -2) * direction;
        }

    }

    /// <summary>
    /// Checks whether the up arrow key is pressed and accelerates/decelerates 
    /// the player based on that
    /// Handles all of the math regarding such a increase/decrease in velocity
    /// </summary>
    public void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            acceleration = accelRate * direction;
            velocity += acceleration;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            deceleration = velocity * decelRate;
            velocity -= deceleration;
        }
        playerPosition += velocity;
    }

    /// <summary>
    /// Handles the actual rotation of the player as well as the official movement
    /// </summary>
    public void SetTransform()
    {
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        ScreenWrap();

        transform.position = playerPosition;

    }

    /// <summary>
    /// Checks the player position and adjusts the position accordingly to make it seem as though
    /// the player never leaves the screen
    /// </summary>
    public void ScreenWrap()
    {
        if (playerPosition.x > width)
        {
            playerPosition.x = -width;
        }
        else if (playerPosition.x < -width)
        {
            playerPosition.x = width;
        }
        if (playerPosition.y > height)
        {
            playerPosition.y = -height;
        }
        else if (playerPosition.y < -height)
        {
            playerPosition.y = height;
        }
    }
    
}
