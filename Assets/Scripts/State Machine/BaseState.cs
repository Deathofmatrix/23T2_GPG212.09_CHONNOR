
using UnityEngine;

public abstract class BaseState
{
    protected StateMachine ctx;
    protected StateFactory factory;

    public BaseState(StateMachine currentContext, StateFactory stateFactory)
    {
        ctx = currentContext;
        factory = stateFactory;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchState();

    public abstract void CheckItemPrice();
    public abstract void OnTriggerEnter(StateMachine stateMachine, Collider collider);
    public abstract void OnTriggerExit(StateMachine stateMachine, Collider collider);   
    
    protected void SwitchStates(BaseState newState)
    {
        ExitState();

        newState.EnterState();

        ctx.CurrentState = newState;
    }

}
