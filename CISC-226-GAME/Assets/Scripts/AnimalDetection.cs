using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDetection : MonoBehaviour
{
    public string Tag = "";
    GameObject[] gos;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gos = GameObject.FindGameObjectsWithTag(Tag);
        if (gos.Length == 2)
            {
                Debug.Log("Text");
                
            }

        

    }
}
