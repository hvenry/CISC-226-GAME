using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : BaseState
{
    //reference to current objects state machine 
    private MovementSM _sm;
    
    // player 
    public Transform target;
    
    // distance which the animal starts to flee from player 
    public float threshold = 25f;
    public Roaming(MovementSM stateMachine) : base("Roam", stateMachine) {
        _sm = stateMachine;
        target = GameObject.FindWithTag("Player").transform;
    }

    public override void Enter()
    {
        //start timer to idle
    }

    public override void UpdateLogic()
    {
        // checks the distance between itself and the player
        // if within threshold range, change to flee state
        Vector2 direction = _sm.rigidbody.position - (Vector2)target.position;
        if (direction.sqrMagnitude < threshold)
        {
            stateMachine.ChangeState(_sm.fleeState);
        }
        // every x seconds go idle 
        // TBC
    }
}