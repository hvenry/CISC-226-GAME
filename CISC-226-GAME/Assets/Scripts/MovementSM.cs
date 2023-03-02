using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    // Access all our animal states (scripts) inside one script
    public Idle idleState;
    public Roaming roamState;
    public Fleeing fleeState;
    public Held heldState;
    public Thrown thrownState;
    public Rigidbody2D rigidbody;

    // Hide HideInInspector makes the variables only accessable in the script
    // [HideInInspector]
    public float speed = 2f;

    // Awake always gets called the first time a game object is created in a scene
    private void Awake()
    {
        // For our movement, we will need to access all animal states inside one script
        // and add them to the animal's state machine
        idleState = new Idle(this);
        roamState = new Roaming(this);
        fleeState = new Fleeing(this);
        heldState = new Held(this);
        thrownState = new Thrown(this);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Override the GetInitialState method to return the initial state of the animal (idleState)
    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
