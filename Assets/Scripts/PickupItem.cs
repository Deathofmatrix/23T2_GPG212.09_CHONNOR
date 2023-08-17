using EasyAudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private Item item;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, 20, transform.position.z);
    }

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
        FindObjectOfType<AudioManager>().Play("PickupItem");
        Destroy(gameObject);
    }
}
