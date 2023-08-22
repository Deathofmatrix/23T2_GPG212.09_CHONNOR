using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private Image itemNPCNeeds;
    [SerializeField] private Image itemNPCGives;

    public void SetImageInformation(Sprite itemNeeded, Sprite itemGiven)
    {
        itemNPCNeeds.sprite = itemNeeded;
        itemNPCGives.sprite = itemGiven;
    }
}
