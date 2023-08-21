using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestGiver : MonoBehaviour
{
    [SerializeField] private Item itemNPCNeeds;
    [SerializeField] private QuestManager questManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show NPC menu or instantly trade with a button press
            //tell the trade button that this is the current Quest NPC
        }
    }

    public void CheckIfItemsMatch()
    {
        if (InventoryManager.instance.GetQuestItem() == itemNPCNeeds)
        {
            Item itemToGive = questManager.CheckItemToGiveToPlayer(itemNPCNeeds);
            InventoryManager.instance.RemoveItem(InventoryManager.instance.GetQuestItem());
            InventoryManager.instance.AddItem(itemNPCNeeds);
        }
    }

}
