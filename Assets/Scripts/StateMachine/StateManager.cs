using System.Collections.Generic;
using UnityEngine;

public class StateManager<EStates> : MonoBehaviour
{
    protected Dictionary<EStates, BaseState<EStates>> States = new Dictionary<EStates, BaseState<EStates>>();
    protected BaseState<EStates> currentState;

    void Start()
    {
        currentState.Enter();
    }

    void Update()
    {
        EStates nextStateKey = GetNextState();
        if (nextStateKey.Equals(currentState.StateKey))
        {
            currentState.Update();
        } else
        {
            ChangeState(nextStateKey);
        }
    }

    public void ChangeState(EStates stateKey)
    {
        currentState.Exit();
        currentState = States[stateKey];
        currentState.Enter();

    }

    EStates GetNextState()
    {
        return default(EStates);
    }
}
