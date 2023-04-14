using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class winCondition : MonoBehaviour
{
    
    private GameObject[] loose = Array.Empty<GameObject>();

    private GameObject[] safe;

    private float timeRemaining = 400f;

    private int total = 0;

    private int safeLength = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        // Debug.Log("Win Condition start");
       Invoke("DelayedStart",1);
    }

    void Switch(int id)
    {
        Debug.Log(String.Format("OnSafe called id: {0}",id));
        
        safe[id] = loose[id];
        safeLength++;
        Debug.Log(String.Format("Length of loose: {0}, safe: {1}. total: {2}",loose.Length, safeLength,total));
        
    }
    
    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        
        if (Won() && total != 0)
        {
            Debug.Log("WON GAME");
            //Trigger end game (WIN)
        }

        if (Lost())
        {
            Debug.Log("You lose!");
            //end game (LOSS)
        }
    }

    private void DelayedStart()
    {
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Cow")).ToArray();
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Pig")).ToArray();
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Hog")).ToArray();
        loose = loose.Concat(GameObject.FindGameObjectsWithTag("Camel")).ToArray();
        total = loose.Length;
        Debug.Log(String.Format("Length of loose: {0}, Loose[0] is type of: {1}", total, loose[0].GetType()));
        EventManager.onSafe += Switch;
        for (int i = 0; i < loose.Length; i++)
        {
            Debug.Log(String.Format("ID: {0}, Object: {1}", i, loose[i]));
            MovementSM x = loose[i].GetComponent<MovementSM>();
            // Debug.Log(String.Format("MovementSM: {0}, Speed: {1}", x, x.speed));
            loose[i].GetComponent<MovementSM>().id = i;
        }

        safe = new GameObject[loose.Length];
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
        return (loose.Length == safeLength);
    }

    bool Lost()
    {
        return timeRemaining <= 0;
    }

}
