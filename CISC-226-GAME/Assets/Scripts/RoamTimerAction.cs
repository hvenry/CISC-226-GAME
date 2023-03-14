using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoamTimerAction: MonoBehaviour, IActionInterface
{
    private MovementSM script;
    

    void Start()
    {
        script = GetComponent<MovementSM>();
    }

    public void Execute()
    {
        if (script.currentState.name == "Idle")
        {
            script.ChangeState(script.roamState);
        }

        if (script.currentState.name == "Roam")
        {
            script.ChangeState(script.idleState);
        }
    }
    
}
