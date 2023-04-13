using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class winCondition : MonoBehaviour
{
    
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
        return (loose.Length == 0);
    }

    bool Lost()
    {
        return timeRemaining <= 0;
    }
}
