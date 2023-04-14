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

    private int total;

    private int safeLength = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Win Condition start");
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
            Debug.Log(String.Format("MovementSM: {0}, Speed: {1}", x, x.speed));
            loose[i].GetComponent<MovementSM>().id = i;
        }

        safe = new GameObject[loose.Length];
    }

    void Switch(int id)
    {
        Debug.Log(String.Format("OnSafe called id: {0}",id));
        safe[id] = loose[id];
        safeLength++;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (Won())
        {
            Debug.Log("WON GAME");
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
        return (loose.Length == safeLength);
    }

    bool Lost()
    {
        return timeRemaining <= 0;
    }
}
