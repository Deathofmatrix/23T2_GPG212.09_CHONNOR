
using UnityEngine;

public class CarrotShop : BaseState
{
    public CarrotShop(StateMachine stateMachine, StateFactory stateFactory)
          : base(stateMachine, stateFactory) { }

    public override void EnterState()
    {
        Debug.Log("You are out at Sea");
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
