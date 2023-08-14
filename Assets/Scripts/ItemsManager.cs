using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    public List<Items> itemsList = new List<Items>();

    public static int priceOfItem;
    
    public int GetPriceOfItem(string itemChoosenToSell)
    {
        Items item = itemsList.Find(x => x.itemName == itemChoosenToSell);

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
