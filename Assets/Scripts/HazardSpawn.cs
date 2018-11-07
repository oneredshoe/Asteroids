using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawn : MonoBehaviour {

    /*
     Leah Bernstein
     This class deals with the creation of the enemy objects, including the instantiation of the secondary enemies and the addition of new enemies as old ones die.
         */

    public Camera cam;
    public GameObject hazard;
    public CollisionManagement collisionManager;
    public List<GameObject> crabs;

    public GameObject[] hazards;
    public int hazardSprite;

    public GameObject secondaryCrab;

    public EnemyMovement enemyMove;
    public int hazardCount;
    public int spawnedHazards;
    public Vector3 position;
    public Vector3 velocity;

    public Vector3 smallerPosition;
    public Vector3 smallerVelocity;

    public float height;
    public float width;


	// Use this for initialization
	void Start () {
        collisionManager = GetComponent<CollisionManagement>();    


        crabs = new List<GameObject>();

        height = cam.orthographicSize;
        width = height * cam.aspect;

        spawnedHazards = 0;
        enemyMove = hazard.GetComponent<EnemyMovement>();
        while (spawnedHazards < hazardCount)
        {
            HazardCreation();
        }
        
        

	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("We get here");
        if (spawnedHazards < hazardCount)
        {
            HazardCreation();
            //Debug.Log("Do we get here?");

            if (collisionManager.isBulletColliding == true)
            {
                //Debug.Log("what about here");
                SecondaryHazardCreation();
                collisionManager.isBulletColliding = false;
            }

        }
	}

    /// <summary>
    /// Creates a random vector3 based on given floats, and then returns a new vector3 to be used outside of this method
    /// </summary>
    /// <param name="xSize">The bounds for the X of the new Vector3, this new float will be a random value between the negative of the given number and the positive</param>
    /// <param name="ySize">The bounds for the Y of the new Vector3, this new float will be a random value between the negative of the given number and the positive</param>
    /// <returns>A new Vector3 made from random floats, the Z is just 0</returns>
    private Vector3 RandomVector3(float xSize, float ySize)
    {
        float x = Random.Range(-xSize, xSize);
        float y = Random.Range(-ySize, ySize);
        return new Vector3(x, y, 0);
    }

    /// <summary>
    /// Creates a new hazard when called, including a random position within the bounds of the screen and a random velocity to move around
    /// it then adds the new hazard to a list in the collision management class
    /// The increase of spawnedHazards is to keep track of how many spawned hazards are on the playing field so that there can be an 
    /// adequate number of total hazards at any point in time
    /// </summary>
    void HazardCreation()
    {
        position = RandomVector3(width, height);
        velocity = RandomVector3(0.05f, 0.05f);

        hazard = hazards[Random.Range(0, hazards.Length)];

        GameObject crab = Instantiate(hazard, position, Quaternion.identity);
        EnemyMovement eScript = crab.GetComponent<EnemyMovement>();
        eScript.position = position;
        eScript.velocity = velocity;
        //crabs.Add(crab);
        collisionManager.crabs.Add(crab);



        spawnedHazards++;
    }

    /// <summary>
    /// Creates the secondary hazards that spawn from the first-level hazards' deaths
    /// Adds them to a different list int he collision management class
    /// </summary>
    void SecondaryHazardCreation()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject crab = Instantiate(secondaryCrab, smallerPosition, Quaternion.identity);
            EnemyMovement eScript = crab.GetComponent<EnemyMovement>();
            eScript.position = smallerPosition;
            eScript.velocity = smallerVelocity;

            collisionManager.smallHazards.Add(crab);

            smallerVelocity.y = -smallerVelocity.y;

        }

    }
}
