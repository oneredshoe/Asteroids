using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour {


    /*Leah Bernstein
     This class is meant to simplify locating and 
     using different sides of the given sprites
     */

    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Is used in conjunction with a given sprite to locate the minimum x of said sprite
    /// </summary>
    /// <returns>The minimum x value of a sprite</returns>
    public float MinX()
    {
        return sprite.bounds.min.x;
    }

    /// <summary>
    /// Is used in conjunction with a given sprite to locate the maximum x of said sprite
    /// </summary>
    /// <returns>The maximum x value of a sprite</returns>
    public float MaxX()
    {
        return sprite.bounds.max.x;
    }

    /// <summary>
    /// Is used in conjunction with a given sprite to locate the maximum y of said sprite
    /// </summary>
    /// <returns>The maximum  yvalue of a sprite</returns>
    public float MaxY()
    {
        return sprite.bounds.max.y;
    }

    /// <summary>
    /// Is used in conjunction with a given sprite to locate the minimum y of said sprite
    /// </summary>
    /// <returns>The minimum y value of a sprite</returns>
    public float MinY()
    {
        return sprite.bounds.min.y;
    }
   
}
