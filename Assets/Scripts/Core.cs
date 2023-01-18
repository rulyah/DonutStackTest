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
        _stateMachine = new StateMachine<Core>(new CreateStickState(this));
    }
}
