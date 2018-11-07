using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    /*
     Leah Bernstein
     This class manages the movement of the bullets after they're spawned
     All variables are created in the Security class
         */

    public Vector3 playerPosition;
    public Vector3 bulletPosition;// = new Vector3(0, 0, 0);
    public Vector3 direction;
    public Vector3 velocity = Vector3.zero;
    public float angleOfRotation = 0f;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        bulletPosition += velocity;

        SetTransform();
	}

    /// <summary>
    /// Manually moves the bullet around, as well as rotate it to match whichever way the player was facing when the bullet was shot
    /// </summary>
    public void SetTransform()
    {
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);       

        transform.position = bulletPosition;

    }
}
