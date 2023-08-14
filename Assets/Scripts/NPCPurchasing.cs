using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPurchasing : MonoBehaviour
{
    

    // this and the Item Manager script are my understanding of how the NPC's would interact with our Inventory
    // If what i've got here won't match up with the Inventory system implemented, let me know
    // main purpose of the 
    private string itemChoosenToSell; 
    public ItemsManager itemsManager; 


    [SerializeField] private string itemWanted;
    [SerializeField] private string itemNeeded;
    [SerializeField] private string itemUnWanted;

    [SerializeField] private int startingMoney;

    private void Start()
    {
        itemChoosenToSell = itemsManager.name;
    }

    public void BuyingPlayersItem()
    {
        // NPc will want the item and pay the regular price for it 
        int itemPrice = itemsManager.GetPriceOfItem(itemChoosenToSell);

        if (itemChoosenToSell == itemWanted)
        {
            PayPrice(itemPrice);
        }

        // they may decde they NEED the item, and pay double the cost
        else if (itemChoosenToSell == itemNeeded)
        {
            PayPrice(itemPrice * 2);
        }

        // if they don't want, or need, they'll politely decline
        else
        {
            Debug.Log("NPC Rejected the item");
        }

    }

    private void PayPrice(int price)
    {

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
