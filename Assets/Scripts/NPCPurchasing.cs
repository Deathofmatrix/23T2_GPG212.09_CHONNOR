using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NPCPurchasing : MonoBehaviour
{

    // this and the Item Manager script are my understanding of how the NPC's would interact with our Inventory
    // If what i've got here won't match up with the Inventory system implemented, let me know
    // main purpose of the 

    

    [SerializeField] private Item.ItemEnum itemNeeded;
    [SerializeField] private Item.ItemEnum itemUnWanted;

    [SerializeField] private int startingMoney;
    [SerializeField] private int currentMoney;

    private void Start()
    {
        currentMoney = startingMoney;
        
    }

    public void BuyingPlayersItem(Item item, out bool didNPCBuy, out int amountPaid)
    {
        //switch(itemEnum)
        //{
        //    case Item.ItemEnum.Apple:
        //        Debug.Log("Apple Item");
        //            break;
        //    case Item.ItemEnum.Pear:
        //        Debug.Log("Pear Item");
        //            break;
        //    case Item.ItemEnum.Carrot:
        //        Debug.Log("Carrot Item");
        //            break;
        //        default:
        //        throw new System.Exception("Invalid Item");
        //}
        


        Item.ItemEnum itemEnum = item.itemEnum;
        // NPC will want the item and pay the regular price for it 
        int itemPrice = item.itemPrice;

        // they may decde they NEED the item, and pay double the cost
        if (itemEnum == itemNeeded)
        {
            PayPrice(itemPrice *2, out didNPCBuy, out amountPaid);
        }

        // if they don't want, or need, they'll politely decline
        else if (itemEnum == itemUnWanted)
        {
            didNPCBuy = true;
            amountPaid = 0;
        }

        else
        {
            PayPrice(itemPrice, out didNPCBuy, out amountPaid);
        }
    }

    private void PayPrice(int price, out bool didNPCBuy, out int amountPaid)
    {
        // I think we will just load the NPC with a fat stack
        if (currentMoney >= price)
        {
            currentMoney -= price;
            Debug.Log("NPc Bought the Item");
            didNPCBuy=true;
            amountPaid=price;
        }
        else
        {
            didNPCBuy=false;
            amountPaid=0;
            Debug.Log("NPC Didn't have enough money");
        }   
    }


}
