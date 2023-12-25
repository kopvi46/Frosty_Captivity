public class PlayerStateManager : StateManager<PlayerStateManager.PlayerStates>
{
    public Initializer _initializer;

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

        bool isMoving = (_initializer.move.x != 0 || _initializer.move.y != 0);

        if (isMoving)
        {
            nextState = PlayerStates.WalkState;
        } else
        {
            nextState = PlayerStates.IdleState;
        }

        if (!currentState.StateKey.Equals(nextState))
        {
            ChangeState(nextState);
        }
    }
}
