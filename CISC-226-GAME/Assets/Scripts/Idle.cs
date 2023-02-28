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
        // _sm.rigidbody.position += new Vector3()
        //start timer for roam
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Vector2 direction = _sm.rigidbody.position - (Vector2)target.position;
        if (direction.sqrMagnitude < 25f)
        {
            stateMachine.ChangeState(_sm.fleeState);
        }
        // every x seconds go roam 
    }
}