using System;
using System.Collections.Generic;
using States;
using UnityEngine;

public class Core : MonoBehaviour
{
    private StateMachine<Core> _stateMachine;

    void Start()
    {
        Model.sticks = new List<Stick>();
        Model.suitableSticks = new List<Stick>();
        Model.checkedSticks = new List<Stick>();
        InitSticksOnScene();
        _stateMachine = new StateMachine<Core>(new CreateStickState(this));
    }

    private void InitSticksOnScene()
    {
        var sticks = FindObjectsOfType<Stick>();
        for (var i = 0; i < sticks.Length; i++)
        {
            Model.sticks.Add(sticks[i]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }
}
