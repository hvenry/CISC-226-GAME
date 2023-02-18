using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleeing : BaseState
{
    private MovementSM _sm;
    public Transform target;
    public Fleeing(MovementSM stateMachine) : base("Flee", stateMachine) {
        _sm = stateMachine;
        target = GameObject.FindWithTag("Player").transform;
    }

    public override void Enter()
    {
        base.Enter();
        //flee for x seconds START TIMER
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Vector3 direction = _sm.rigidbody.position - target.position;
        _sm.rigidbody.MovePosition(_sm.rigidbody.position + direction.normalized * Time.deltaTime * _sm.speed);
        
        //if timer above threshold return to idle if out of range
    }
}