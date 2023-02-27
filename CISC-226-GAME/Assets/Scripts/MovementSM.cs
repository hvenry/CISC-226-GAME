using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Roaming roamState;
    [HideInInspector]
    public Fleeing fleeState;

    public Rigidbody rigidbody;
    public float speed = 2f;

    private void Awake()
    {
        idleState = new Idle(this);
        roamState = new Roaming(this);
        fleeState = new Fleeing(this);
        rigidbody = GetComponent<Rigidbody>();
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
