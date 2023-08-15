using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : BaseState
{
    public ShopState(StateMachine stateMachine, StateFactory stateFactory)
         : base(stateMachine, stateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Hello from the Shop State");

        ctx.PressE.enabled = true;
        ctx.IsInShop = true;
        // try calling the panel to turn on at start and stay on whilst in the shop zone
        Debug.Log("Press E is on");
    }

    public override void UpdateState()
    {

        // Run Shop
        // Call Purchasing Method
        if (Input.GetKeyUp(KeyCode.E) && ctx.IsInShop == true)
        {
            ctx.ShopPanel.SetActive(true);
        }
        // bring up the text that tells the player to press E
        // may need to work out how to turn it off

        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        // OnTriggerExit
        // call switchStates()
    }

    public override void ExitState() {    }

    public override void OnTriggerEnter(StateMachine stateMachine, Collider collider) {    }

    public override void OnTriggerExit(StateMachine stateMachine, Collider collider)
    {
        GameObject go = collider.gameObject;

        if (go.CompareTag("Shop"))
        {
            SwitchStates(factory.NoShopState());
        }
    }
}
