using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public Item[] questItems;

    [SerializeField] private GameObject questCanvas;
    [SerializeField] private Item currentNPCNeededItem;

    private void Awake()
    {
        instance = this;
    }

    public void ShowQuestCanvas(Item itemNeeded)
    {
        currentNPCNeededItem = itemNeeded;
        Item itemGiven = CheckItemToGiveToPlayer(itemNeeded);
        questCanvas.GetComponent<QuestPanel>().SetImageInformation(itemNeeded.itemImage, itemGiven.itemImage);
        questCanvas.SetActive(!questCanvas.activeInHierarchy);
    }

    public Item CheckItemToGiveToPlayer(Item itemTakenFromPlayer)
    {
        for (int i = 0; i < questItems.Length; i++)
        {
            if (questItems[i] == itemTakenFromPlayer)
            {
                Item itemToGive = questItems[i + 1];
                return itemToGive;
            }
        }

        return null;
    }

    public void TradeItem()
    {
        CheckIfItemsMatch();
    }

    public void CheckIfItemsMatch()
    {
        Item currentQuestItem = InventoryManager.instance.GetQuestItem().item;
        if (currentQuestItem == currentNPCNeededItem)
        {
            Item itemToGive = CheckItemToGiveToPlayer(currentNPCNeededItem);
            InventoryManager.instance.SwapItem(currentQuestItem, itemToGive);
        }
        else
        {
            Debug.Log("Dont have correct Item");
        }
    }
}
