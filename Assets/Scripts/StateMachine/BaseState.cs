public abstract class BaseState<EStates>
{
    public BaseState(EStates key)
    {
        StateKey = key;
    }

    public EStates StateKey { get; private set; }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
