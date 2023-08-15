
using UnityEngine;

public class CarrotShop : BaseState
{
    public CarrotShop(StateMachine stateMachine, StateFactory stateFactory)
          : base(stateMachine, stateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Hello from the Carrot Shop");
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
        if (collider.CompareTag("Shop"))
        {
            //popup "E to interact"
            //populate NPC Inventory
        }
    }

    public override void OnTriggerExit(StateMachine stateMachine, Collider collider)
    {
        GameObject go = collider.gameObject;

        if (go.CompareTag("CarrotShop"))
        {
            SwitchStates(factory.NoShopState());
        }
    }
}
