using UnityEngine;

public abstract class State
{
    protected MonoBehaviour owner; // Player hoặc Enemy
    protected StateMachine stateMachine;

    public State(MonoBehaviour owner, StateMachine stateMachine)
    {
        this.owner = owner;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void LogicUpdate() { }
    public virtual void Exit() { }
}
