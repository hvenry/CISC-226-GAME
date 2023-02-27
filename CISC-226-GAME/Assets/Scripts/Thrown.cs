using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : BaseState
{
    public Vector3 start;
    private Vector3 worldPosition;
    protected float timePassed;
    private MovementSM _sm;
    public Transform target;
    public Thrown(MovementSM stateMachine) : base("Thrown", stateMachine) {
        _sm = stateMachine;
        target = GameObject.FindWithTag("Player").transform;
    }

    public override void Enter()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        start = target.position;

        
    }

    public override void UpdateLogic()
    {
        if (timePassed > 5f)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
        timePassed += Time.deltaTime;
        _sm.rigidbody.transform.position = MathParabola.Parabola(start, worldPosition, 5f, timePassed / 5f);

        // every x seconds go roam 
    }
}