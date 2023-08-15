using System;
using UnityEngine;

public class TestItemManager : MonoBehaviour
{
    public ItemsManager itemsManager; // Assign the ItemsManager in the Inspector

    private void Start()
    {
        TestGetPriceOfItem();
    }

    private void TestGetPriceOfItem()
    {
        Item.ItemEnum itemName = Item.ItemEnum.Apple; // Replace with the name of the item you want to test

        int itemPrice = itemsManager.GetPriceOfItem(itemName);

        if (itemPrice > 0)
        {
            Debug.Log("Item price: " + itemPrice);
        }
        else
        {
            Debug.Log("Item not found or price is zero.");
        }
    }
}
