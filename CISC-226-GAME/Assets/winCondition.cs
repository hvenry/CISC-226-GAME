using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class winCondition : MonoBehaviour
{
<<<<<<< Updated upstream
    
    private GameObject[] loose;

    private GameObject[] safe;

    private float timeRemaining;

    private float total;
    // Start is called before the first frame update
    void Start()
    {
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Cow")).ToArray();
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Pig")).ToArray();
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Hog")).ToArray();
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Camel")).ToArray();
        total = loose.Length;
        timeRemaining = 400f;
        EventManager.onSafe += Switch;
=======
    private GameObject[] cows;
    private GameObject[] pigs;
    private GameObject[] hogs;
    private GameObject[] chickens;
    private GameObject[] safe;

    private float timeRemaining = 120f;
    // Start is called before the first frame update
    void Start()
    {
        cows = GameObject.FindGameObjectsWithTag("Cow");
        Debug.Log(cows);
        pigs = GameObject.FindGameObjectsWithTag("Pig");
        hogs = GameObject.FindGameObjectsWithTag("Hog");
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
>>>>>>> Stashed changes
    }

    void Switch(float id)
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (Won())
        {
            Debug.Log("You win!");
            //Trigger end game (WIN)
        }

        if (Lost())
        {
            Debug.Log("You lose!");
            //end game (LOSS)
        }
    }



    private void OnGUI()
    {
        // Calculate the time remaining as an integer number of minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Create a string to display the time remaining in minutes and seconds
        string timeRemainingString = string.Format("TIME: {0:00}:{1:00}", minutes, seconds);

        // change font of GUI
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;

        // Measure the width of the label based on the text and style
        Vector2 size = style.CalcSize(new GUIContent(timeRemainingString));

        // Set the position and size of the label
        Rect labelRect = new Rect((Screen.width - size.x) / 2, 30, size.x, 40);

        // Display the label
        GUI.Label(labelRect, timeRemainingString, style);
    }

    bool Won()
    {
<<<<<<< Updated upstream
        return (loose.Length == 0);
=======
        return (cows == null || cows.Length == 0) && 
            (pigs == null || pigs.Length == 0) && 
            (hogs == null || hogs.Length == 0) && 
            (chickens == null || chickens.Length == 0);
>>>>>>> Stashed changes
    }

    bool Lost()
    {
        return timeRemaining <= 0;
    }

}
