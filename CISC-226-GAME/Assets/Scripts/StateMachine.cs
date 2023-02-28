using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }


    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }
    private void OnGUI()
    {
        if ((currentState.name == "Held")|(currentState.name == "Thrown"))
        {
            string content = currentState != null ? currentState.name : "(NA)";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        }
        
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}