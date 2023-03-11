using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleeing : BaseState
{
    private MovementSM _sm;
    
    // player reference 
    private Transform target;
    public Fleeing(MovementSM stateMachine) : base("Flee", stateMachine) {
        _sm = stateMachine;
        target = GameObject.FindWithTag("Player").transform;
    }

    public override void Enter()
    {
        // not yet implemented
        //flee for x seconds START TIMER
    }

    public override void UpdateLogic()
    {
        // direction points away from player
        Vector2 direction = _sm.rigidbody.position - (Vector2)target.position;
        
        // move animal away from player
        _sm.rigidbody.MovePosition(_sm.rigidbody.position + direction.normalized * Time.deltaTime * _sm.speed);
        
        //not yet implemented
        //if timer above threshold return to idle if out of range
    }
}