using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManagement : MonoBehaviour {

    /*
     Leah Bernstein
     This class manages all of the collisions for the game, including player X hazards, bullet X hazards, and bullet X smallerHazards
         */

    public List<GameObject> crabs;
    public List<GameObject> bullets;
    public List<GameObject> smallHazards;

    public GameObject player;
    public Movement sScript;

    private CollisionDetector detection;
    private GUIManager gui;

    public HazardSpawn spawner;

    public EnemyMovement eScript;

    public BulletMovement bScript;

    public bool isColliding;
    public bool isBulletColliding;
 
    SpriteRenderer playerRender;

    public bool immunity;
    public int timer;
    

    // Use this for initialization
    void Start()
    {
        detection = GetComponent<CollisionDetector>();
        gui = GetComponent<GUIManager>();
        spawner = GetComponent<HazardSpawn>();

        isColliding = false;
        isBulletColliding = false;

        playerRender = player.GetComponent<SpriteRenderer>();
        sScript = player.GetComponent<Movement>();

        immunity = true;
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (immunity == false) //Immunity is so that the player doesn't immediately die upon entering the game, and after each death can have something of a respawn timeframe
        {
            for (int i = 0; i < crabs.Count; i++)
            {
                //Debug.Log(crabs[i]);

                ///Collisions between crabs and the player
                if (detection.AABBCollision(crabs[i], player))
                {
                    eScript = crabs[i].GetComponent<EnemyMovement>();
                    eScript.position = new Vector3(-200, -200, 0);
                    eScript.velocity = Vector3.zero;

                    sScript.playerPosition = Vector3.zero; 

                    spawner.spawnedHazards--;
                    immunity = true;
                    gui.lives--;
                    isColliding = true;
                    break;
                }
                else
                {
                    playerRender.color = Color.white;
                    isColliding = false;
                }

            }

            ///Collsions between bullets and crabs
            for (int i = 0; i < crabs.Count; i++)
            {
                for (int j = 0; j < bullets.Count; j++)
                {
                    if (detection.AABBCollision(crabs[i], bullets[j]))
                    {
                        eScript = crabs[i].GetComponent<EnemyMovement>();
                        bScript = bullets[j].GetComponent<BulletMovement>();

                        spawner.smallerPosition = eScript.position;
                        spawner.smallerVelocity = eScript.velocity;


                        eScript.position = new Vector3(-200, -200, 0);
                        bScript.bulletPosition = new Vector3(200, 200, 0);
                        eScript.velocity = Vector3.zero;
                        bScript.velocity = Vector3.zero;

                        gui.points += 20;
                        spawner.spawnedHazards--;

                        isBulletColliding = true;
                        break;
                    }
                    
                }
            }

            ///Collisions between smaller hazards and player
            for (int i = 0; i < smallHazards.Count; i++)
            {
                if (detection.AABBCollision(smallHazards[i], player))
                {
                    eScript = smallHazards[i].GetComponent<EnemyMovement>();
                    eScript.position = new Vector3(-200, -200, 0);
                    eScript.velocity = Vector3.zero;

                    sScript.playerPosition = Vector3.zero;

                    immunity = true;
                    gui.lives--;
                    isColliding = true;
                    break;
                }
                else
                {
                    isColliding = false;
                }

            }

            ///Collisions between smaller hazards and bullets
            for (int i = 0; i < smallHazards.Count; i++)
            {
                for (int j = 0; j < bullets.Count; j++)
                {
                    if (detection.AABBCollision(smallHazards[i], bullets[j]))
                    {
                        eScript = smallHazards[i].GetComponent<EnemyMovement>();
                        bScript = bullets[j].GetComponent<BulletMovement>();

                        eScript.position = new Vector3(-200, -200, 0);
                        bScript.bulletPosition = new Vector3(200, 200, 0);
                        eScript.velocity = Vector3.zero;
                        bScript.velocity = Vector3.zero;

                        gui.points += 50;

                        isBulletColliding = true;
                        break;
                    }
                    
                }
            }
        }

        if (immunity == true)
        {
            playerRender.color = Color.magenta;
            timer++;
        }
        if (timer >= 40)
        {
            immunity = false;
            timer = 0;
        }

        if (gui.lives <= 0) //If dead, move all of the enemies off the playing field so the player cannot get any more points/lose any more lives before the game closes itself
        {
            for (int i = 0; i < crabs.Count; i++)
            {
                eScript = crabs[i].GetComponent<EnemyMovement>();
                eScript.position = new Vector3(-200, -20, 0);
                eScript.velocity = Vector3.zero;
            }
            for (int j = 0; j < smallHazards.Count; j++)
            {
                eScript = smallHazards[j].GetComponent<EnemyMovement>();
                eScript.position = new Vector3(-200, -20, 0);
                eScript.velocity = Vector3.zero;
            }
        }

    }


}
