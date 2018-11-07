using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

    /*
     Leah Bernstein
     This class manages the health, points, and overall GUI of the game
         */

    Camera cam;

    public float height;
    public float width;

    public int points;
    public int lives;


	// Use this for initialization
	void Start () {
        cam = Camera.main;
        height = cam.orthographicSize;
        width = height * cam.aspect;


	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

	}
    private void OnGUI()
    {

        GUI.color = Color.white;
        GUI.skin.box.fontSize = 20;
        GUI.skin.box.wordWrap = true;
        GUI.Box(new Rect(10,10, 100,100), "Lives: " + lives + " \nPoints: " + points);

        if (lives <= 0)
        {
            GUI.skin.box.fontSize = 100;
            GUI.Box(new Rect(300,225, 300, 250), "Game Over");

            Invoke("Quit", 5);
        }
    }

    /// <summary>
    /// It's just a method to assist in quitting the game after the player gets a game over
    /// </summary>
    void Quit()
    {
        Application.Quit();
    }
}
