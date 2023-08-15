using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPurchasing : MonoBehaviour
{


    // this and the Item Manager script are my understanding of how the NPC's would interact with our Inventory
    // If what i've got here won't match up with the Inventory system implemented, let me know
    // main purpose of the 
    [SerializeField] private Item.ItemEnum itemChosenToSell;
    public ItemsManager itemsManager;

    [SerializeField] private Item.ItemEnum itemWanted;
    [SerializeField] private Item.ItemEnum itemNeeded;
    [SerializeField] private Item.ItemEnum itemUnWanted;

    [SerializeField] private int startingMoney;

    private void Start()
    {
        itemChosenToSell = itemsManager.itemsList[0].itemEnum;
        Debug.Log(itemChosenToSell);
    }

    public void BuyingPlayersItem()
    {
        // NPc will want the item and pay the regular price for it 
        int itemPrice = itemsManager.GetPriceOfItem(itemChosenToSell);

        if (itemChosenToSell == itemWanted)
        {
            PayPrice(itemPrice);
        }

        // they may decde they NEED the item, and pay double the cost
        else if (itemChosenToSell == itemNeeded)
        {
            PayPrice(itemPrice * 2);
        }

        // if they don't want, or need, they'll politely decline
        else if (itemChosenToSell == itemUnWanted)
        {
            Debug.Log("NPC Rejected the item");
        }

    }

    private void PayPrice(int price)
    {
        // I think we will just load the NPC with a fat stack
        if (startingMoney >= price)
        {
            startingMoney -= price;
            Debug.Log("NPc Bought the Item");
        }
        else
        {
            Debug.Log("NPC Didn't have enough money");
        }
            
    }


}
