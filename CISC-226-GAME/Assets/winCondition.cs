using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class winCondition : MonoBehaviour
{
    private GameObject[] cows;

    private GameObject[] pigs;

    private GameObject[] hogs;

    private GameObject[] chickens;

    private GameObject[] safe;

    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        cows = GameObject.FindGameObjectsWithTag("Cow");
        pigs = GameObject.FindGameObjectsWithTag("Pig");
        hogs = GameObject.FindGameObjectsWithTag("Hog");
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
        timeRemaining = 400f;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (Won())
        {
            //Trigger end game (WIN)
        }

        if (Lost())
        {
            //end game (LOSS)
        }
    }

    private void OnGUI()
    {
        //add progress bar for each animal 
    }

    bool Won()
    {
        return (cows.Length == 0 & pigs.Length == 0 & hogs.Length == 0 & chickens.Length == 0);
    }

    bool Lost()
    {
        if (timeRemaining <= 0)
        {
            return true;
        }

        return false;
    }
}
