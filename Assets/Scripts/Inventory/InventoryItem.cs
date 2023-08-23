using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item;
    public Transform parentAfterDrag;
    public bool isQuestitem;

    private Item.ItemEnum itemType;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    [SerializeField] private GameObject hoverPanelGO;
    [SerializeField] private InventorySlot sellPanelSlot;

    private int itemPrice;
    //private string itemText;

    [SerializeField] private int tapTimes;
    [SerializeField] private float resetDoubleClickTimerSeconds;

    public void InitialiseItem(Item newItem, InventorySlot sellSlot)
    {
        item = newItem;

        image.sprite = newItem.itemImage;

        itemType = newItem.itemEnum;
        itemPrice = newItem.itemPrice;
        //itemText = newItem.itemText;
        sellPanelSlot = sellSlot;
        isQuestitem = newItem.isQuestItem;

        itemPriceText.text = $"${itemPrice}";
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Entered");
        hoverPanelGO.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exited");
        hoverPanelGO.SetActive(false);
    }

    private IEnumerator ResetTapTimer()
    {
        yield return new WaitForSeconds(resetDoubleClickTimerSeconds);
        tapTimes = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(ResetTapTimer());
        tapTimes++;

        if (tapTimes <= 2)
        {
            tapTimes = 0;
            MoveToSellSlot();
        }
    }

    public void MoveToSellSlot()
    {
        if (sellPanelSlot.transform.childCount == 0 && sellPanelSlot.gameObject.activeInHierarchy)
        {
            transform.SetParent(sellPanelSlot.transform);
        }
    }
}
