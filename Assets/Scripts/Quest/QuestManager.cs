using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Item[] questItems;

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
}
