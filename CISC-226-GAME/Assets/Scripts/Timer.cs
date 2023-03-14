using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _totalTime;
    private float _timeRemaining;
    private bool _isRunning;
    private IActionInterface _action;

    public Timer(float totalTime, IActionInterface action)
    {
        _totalTime = totalTime;
        _action = action;
    }

    private void Start()
    {
        StartCoroutine(DoTimer());
    }

    void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
        }
    }

    private IEnumerator DoTimer()
    {
        yield return new WaitForSeconds(_totalTime);
        _action.Execute();
        yield return null;
    }
}