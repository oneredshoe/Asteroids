using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour {

    /*
     Leah Bernstein
     This class is used by the player object to track input in regards to bullet creation
     and then spawn the bullets in the proper position with a relevant velocity
     Known Errors: Doesn't restirct how many bullets can be shot/ delay between bullets
         */


    public GameObject bulletPrefab;
    public Vector3 bulletPosition;

    public GameObject manager;
    public CollisionManagement collisionManager;

    public Movement playerMovement;

	// Use this for initialization
	void Start () {

        collisionManager = manager.GetComponent<CollisionManagement>();

    }

    // Update is called once per frame
    void Update() {



        Invoke("BulletSpawn", 2);

	}

    /// <summary>
    /// Tracks the usage of the space bar and upon it being pressed, it creates a bullet
    /// that matches the player's given position and a velocity that is slightly faster
    /// It then adds that bullet to a list in the collision management class
    /// </summary>
    public void BulletSpawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement = GetComponent<Movement>();
            bulletPosition = playerMovement.playerPosition;
            //Debug.Log("Player position: " + playerMovement.GetPosition());
            
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
            BulletMovement bScript = bullet.GetComponent<BulletMovement>();
            bScript.angleOfRotation = playerMovement.angleOfRotation;
            bScript.direction = playerMovement.direction;
            bScript.velocity = playerMovement.velocity + (playerMovement.velocity * 2);
            bScript.bulletPosition = playerMovement.playerPosition;

            collisionManager.bullets.Add(bullet);
            
            // Debug.Log("Movement Velocity: " + movement.GetVelocity());

            // Debug.Log("Bullet velocity: " + velocity);
            //bScript.bulletPosition = new Vector3(bullet.transform.position.x, bullet.transform.position.y, 0);
            //Debug.Log("Bullet Position: " + bulletPosition);

            //direction = playerMovement.GetDirection();
            //velocity = playerMovement.GetVelocity();
            //angleOfRotation = playerMovement.GetAngleOfRotation();
            ////positions[bullets.Length] = bulletPosition;
            ////velocities[bullets.Length] = velocity;
            ////bullets[bullets.Length] = bullet;

            //// Debug.Log("Bullets :  " + bullets);
            //// Debug.Log("Velocities : " + velocities);
            //// Debug.Log("Positions : " + positions);
            //Debug.Log(bullets.Length);


        }
        
    }

}
