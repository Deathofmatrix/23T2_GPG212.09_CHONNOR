using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Item[] startItems;

    public InventorySlot[] inventorySlots;
    public InventorySlot sellSlot;
    public GameObject inventoryItemPrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach(Item item in startItems)
        {
            AddItem(item);
        }
    }
    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null )
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot.item == item )
            {
                Destroy(itemInSlot.gameObject);
                return;
            }
        }
    }

    public void SwapItem(Item itemToRemove, Item itemToSpawn)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot.item == itemToRemove)
            {
                Destroy(itemInSlot.gameObject);
                SpawnNewItem(itemToSpawn, slot);
                return;
            }
        }
    }

    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        Debug.Log("Spawn Item");
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item, sellSlot);
    }

    public InventoryItem GetQuestItem()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot.isQuestitem)
            {
                return itemInSlot;
            }
        }
        Debug.Log("No Quest Item In inventory");
        return null;
    }
}
