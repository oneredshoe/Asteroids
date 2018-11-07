using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    /*
     Leah Bernstein
     This class manages the actual collsions process, checking to see if the two given objects are colliding in any way
         */

    public SpriteInfo sPInfo;
    public SpriteInfo sSInfo;
    public float distance;
    

    // Use this for initialization
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Collisions check on two given objects based on their sprites' bounds
    /// </summary>
    /// <param name="a">First game object to check</param>
    /// <param name="b">Second game object to check</param>
    /// <returns>Whether or not the two objects are colliding</returns>
    public bool AABBCollision(GameObject a, GameObject b)
    {
        sPInfo = a.GetComponent<SpriteInfo>();
        sSInfo = b.GetComponent<SpriteInfo>();
        if (sPInfo.MaxX() >= sSInfo.MinX() && sPInfo.MinX() <= sSInfo.MaxX())
        {
            if (sPInfo.MaxY() >= sSInfo.MinY() && sPInfo.MinY() <= sSInfo.MaxY())
                return true;
        }

        return false;
    }

   
}
