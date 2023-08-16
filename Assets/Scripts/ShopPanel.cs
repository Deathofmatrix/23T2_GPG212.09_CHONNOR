using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public delegate void ClickAction(Item item);
    public static event ClickAction OnButtonPressed;

    [SerializeField] private InventorySlot inventorySlot;
    [SerializeField] private InventoryItem inventoryItem;

    [SerializeField] private Item item;

    public void GetItem()
    {
        inventoryItem = inventorySlot.GetComponentInChildren<InventoryItem>();
        item = inventoryItem.item;
        // Debug.Log("Item is " + item);
    }

    private void Update()
    {
        if(inventoryItem == null && item == null)
        {
            //Debug.Log("InvItem == null and item == null");
            if (inventorySlot.transform.childCount != 0)
            {
                //Debug.Log("Child count not zero");
                GetItem(); 
            }
        }

        if(inventorySlot.transform.childCount == 0)
        {
            inventoryItem = null;
            item = null;
        }
    }
    public void SellItem()
    {
        
        if(OnButtonPressed != null)
        {
            OnButtonPressed(item);
        }
        //Destroy(inventoryItem.gameObject);
        //item = null;

    }
    public Item DestroyItem()
    {
        Item itemDestroyed = item;
        if(inventoryItem != null) Destroy(inventoryItem.gameObject);
        item = null;
        return itemDestroyed;
        //inventoryItem = null;
    }
}
