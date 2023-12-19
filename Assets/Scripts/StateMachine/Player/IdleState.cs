using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState<PlayerStateManager.PlayerStates>
{
    public IdleState(PlayerStateManager.PlayerStates key) : base(key) { }
    public override void Enter()
    {
        //Debug.Log("Entered Idle State");
    }
    public override void Exit()
    {
        //Debug.Log("Exited Idle State");
    }
    public override void Update()
    {

    }
}
