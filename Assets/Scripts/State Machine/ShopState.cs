using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        // bring up the text that tells the player to press E
        // may need to work out how to turn it off

        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        // OnTriggerExit
        // call switchStates()
    }

    public override void ExitState() 
    {
        ctx.shopPanelGO.SetActive(false);
        ctx.isShopOpen = false;

        if (ctx.InventorySlot.transform.childCount != 0)
        {
            Debug.Log("Got passed Check");
            Item itemDestroyed = ctx.shopPanelGO.GetComponent<ShopPanel>().DestroyItem();
            Debug.LogWarning(itemDestroyed);
            InventoryManager.instance.AddItem(itemDestroyed);
        }

    }

    public override void OnTriggerEnter(StateMachine stateMachine, Collider collider) {    }

    public override void OnTriggerExit(StateMachine stateMachine, Collider collider)
    {
        GameObject go = collider.gameObject;

        if (go.CompareTag("Shop"))
        {
            ctx.currentNPC = null;
            SwitchStates(factory.NoShopState());
        }

    }

    public override void CheckItemPrice()
    {
        bool didNPCBuyTemp = true;
        int amountPaidTemp = 0;
        ctx.CurrentNPC.BuyingPlayersItem(ctx.CurrentItem, out didNPCBuyTemp, out amountPaidTemp);

        if(didNPCBuyTemp)
        {
            MoneyManager.AddMoney(amountPaidTemp);
            ctx.shopPanelGO.GetComponent<ShopPanel>().DestroyItem();
        }
        else
        {
            Debug.Log("Didn't have enough money");
        }
    }

}
