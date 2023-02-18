using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    private MovementSM _sm;
    public Transform target;
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) {
        _sm = stateMachine;
        target = GameObject.FindWithTag("Player").transform;
    }

    public override void Enter()
    {
        base.Enter();
        //start timer for roam
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Vector3 direction = _sm.rigidbody.position - target.position;
        if (direction.sqrMagnitude < 25f)
        {
            stateMachine.ChangeState(_sm.fleeState);
        }
        // every x seconds go roam 
    }
}