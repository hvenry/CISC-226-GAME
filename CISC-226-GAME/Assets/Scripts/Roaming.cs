using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : BaseState
{
    private MovementSM _sm;
    public Transform target;
    private float _horizontalInput;
    public Roaming(MovementSM stateMachine) : base("Roam", stateMachine) {
        _sm = stateMachine;
        target = GameObject.FindWithTag("Player").transform;
    }

    public override void Enter()
    {
        base.Enter();
        //start timer to idle
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Vector2 direction = _sm.rigidbody.position - (Vector2)target.position;
        if (direction.sqrMagnitude < 25f)
        {
            stateMachine.ChangeState(_sm.fleeState);
        }
        // every x seconds go idle 
    }
}