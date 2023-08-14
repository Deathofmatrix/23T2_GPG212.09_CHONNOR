
using Unity.VisualScripting;
using UnityEngine;

public class NoShop : BaseState
{
    public NoShop(StateMachine stateMachine, StateFactory stateFactory)
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
        // call switchStates()
    }

    public override void ExitState()
    {

    }

    public override void OnTriggerEnter(StateMachine stateMachine, Collider collider)
    {
        GameObject go = collider.gameObject;

        if(go.CompareTag("AppleShop"))
        {
            SwitchStates(factory.AppleShopState());
        }
    }
}
