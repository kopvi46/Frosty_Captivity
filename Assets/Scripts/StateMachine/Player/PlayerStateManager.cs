using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerStateManager : StateManager<PlayerStateManager.PlayerStates>
{

    public enum PlayerStates
    {
        IdleState,
        WalkState
    }

    void Awake()
    {
        States.Add(PlayerStates.IdleState, new IdleState(PlayerStates.IdleState));
        States.Add(PlayerStates.WalkState, new WalkState(PlayerStates.WalkState));

        currentState = States[PlayerStates.IdleState];
    }

    void Update()
    {
        PlayerStates nextState = currentState.StateKey;
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            nextState = PlayerStates.WalkState;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            nextState = PlayerStates.IdleState;
        }

        if (!currentState.StateKey.Equals(nextState))
        {
            ChangeState(nextState);
        }
    }
}
