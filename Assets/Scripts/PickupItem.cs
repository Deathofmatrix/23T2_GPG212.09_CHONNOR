using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private Item item;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TestForPickup();
        }
    }

    public void TestForPickup()
    {
        bool canPickUp = InventoryManager.instance.AddItem(item);

        if (canPickUp)
        {
            PickUpItem();
        }
    }

    public void PickUpItem()
    {
        Destroy(gameObject);
    }
}
