using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public delegate void UpgradePlayer(int upgradeNumber);
    public static event UpgradePlayer OnGiveUpgrade;

    public Item[] questItems;

    [SerializeField] private GameObject questCanvas;
    [SerializeField] private Item currentPlayerQuestItem;
    [SerializeField] private Item currentNPCNeededItem;
    [SerializeField] private int currentPlayerItemIndex;
    [SerializeField] private int currentNPCItemIndex;

    private void Awake()
    {
        instance = this;
    }

    public void ShowQuestCanvas(Item itemNeeded)
    {
        currentPlayerQuestItem = InventoryManager.instance.GetQuestItem().item;
        currentNPCNeededItem = itemNeeded;
        currentPlayerItemIndex = FindCurrentQuestItemIndex(currentPlayerQuestItem);
        currentNPCItemIndex = FindCurrentQuestItemIndex(currentNPCNeededItem);

        Item itemGiven = CheckItemToGiveToPlayer(itemNeeded);
        questCanvas.GetComponent<QuestPanel>().SetImageInformation(itemNeeded, itemGiven, CheckIfItemAlreadyTraded());

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
        if (CheckIfItemsMatch())
        {
            Item itemToGive = CheckItemToGiveToPlayer(currentNPCNeededItem);
            InventoryManager.instance.SwapItem(currentPlayerQuestItem, itemToGive);

            questCanvas.GetComponent<QuestPanel>().SetImageInformation(currentNPCNeededItem, itemToGive, true);
            currentPlayerItemIndex = FindCurrentQuestItemIndex(currentPlayerQuestItem);
            currentNPCItemIndex = FindCurrentQuestItemIndex(currentNPCNeededItem);
            OnGiveUpgrade?.Invoke(currentPlayerItemIndex);
        }
    }

    public bool CheckIfItemAlreadyTraded()
    {
        if (!CheckIfItemsMatch())
        {
            if (currentPlayerItemIndex > currentNPCItemIndex)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckIfItemsMatch()
    {
        if (currentPlayerQuestItem == currentNPCNeededItem)
        {
            questCanvas.GetComponentInChildren<Button>().interactable = true;
            return true;
        }
        else
        {
            questCanvas.GetComponentInChildren<Button>().interactable = false;
            Debug.Log("Dont have correct Item");
            return false;
        }
    }

    public int FindCurrentQuestItemIndex(Item indexOfThisItem)
    {
        for (int i = 0; i < questItems.Length; i++)
        {
            if (questItems[i] == indexOfThisItem)
            {
                return i;
            }
        }
        Debug.LogWarning("No index of current quest item");
        return -1;
    }
}
