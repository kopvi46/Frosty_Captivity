using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : BaseState<PlayerStateManager.PlayerStates>
{
    public WalkState(PlayerStateManager.PlayerStates key) : base(key) { }
    public override void Enter()
    {
        //Debug.Log("Entered Walk State");
    }
    public override void Exit()
    {
        //Debug.Log("Exited Walk State");
    }
    public override void Update()
    {

    }
}
