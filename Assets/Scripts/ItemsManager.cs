using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    public List<Item> itemsList = new List<Item>();

    public static int priceOfItem;
    
    public int GetPriceOfItem(Item.ItemEnum itemChoosenToSell)
    {
        Item item = itemsList.Find(x => x.itemEnum == itemChoosenToSell);

        if (item != null)
        {
            return item.itemPrice;
        }

        else
        {
            Debug.LogWarning("Item not found in list");
            return 0;
        }
    }
   

}
