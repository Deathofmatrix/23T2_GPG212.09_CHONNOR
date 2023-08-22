using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestGiver : MonoBehaviour
{
    [SerializeField] private Item itemNPCNeeds;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entering trigger as player");
            QuestManager.instance.ShowQuestCanvas(itemNPCNeeds);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exiting trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited trigger as player");
            QuestManager.instance.ShowQuestCanvas(itemNPCNeeds);
        }
    }

}
