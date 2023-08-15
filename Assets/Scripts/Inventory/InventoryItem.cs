using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public Transform parentAfterDrag;

    private Item.ItemEnum itemType;
    [SerializeField] private Image image;
    private int itemPrice;
    private string itemText;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;

        image.sprite = newItem.itemImage;

        itemType = newItem.itemEnum;
        itemPrice = newItem.itemPrice;
        itemText = newItem.itemText;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.parent.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
