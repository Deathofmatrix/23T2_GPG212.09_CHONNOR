
using UnityEngine;

public class AppleShop : BaseState
{
    public AppleShop(StateMachine stateMachine, StateFactory stateFactory)
        : base(stateMachine, stateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Hello from the Apple Shop");
    }

    public override void UpdateState()
    {

        // Run Shop
        // Call Purchasing Method

        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        // OnTriggerExit
        // call switchStates()
    }

    public override void ExitState()
    {

    }

    public override void OnTriggerEnter(StateMachine stateMachine, Collider collider)
    {


    }
}
