using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TestItemSpawning : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToSpawn;
    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToSpawn[id]);
        if (result)
        {
            Debug.Log("Item Has Been Spawned");
        }
        else
        {
            Debug.LogError("No Space For Item!!!!!");
        }
    }
}
