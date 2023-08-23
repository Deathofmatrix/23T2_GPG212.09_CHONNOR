using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private Image itemNPCNeeds;
    [SerializeField] private Image itemNPCGives;

    [SerializeField] private TextMeshProUGUI npcText;

    public void SetImageInformation(Item itemNeeded, Item itemGiven, bool isItemAlreadyTraded)
    {
        itemNPCNeeds.sprite = itemNeeded.itemImage;
        itemNPCGives.sprite = itemGiven.itemImage;

        if (isItemAlreadyTraded)
        {
            npcText.text = itemNeeded.givenItemDescription;
        }
        else
        {
            npcText.text = itemNeeded.wantingItemDescription;
        }
    }
}
