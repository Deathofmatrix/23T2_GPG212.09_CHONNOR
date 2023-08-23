using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public MonoBehaviour[] upgrades;

    private void OnEnable()
    {
        QuestManager.OnGiveUpgrade += GiveUpgrade;
    }

    private void OnDisable()
    {
        QuestManager.OnGiveUpgrade -= GiveUpgrade;
    }

    public void GiveUpgrade(int upgradeNumber)
    {
        if (upgradeNumber > upgrades.Length - 1) return;

        upgrades[upgradeNumber].enabled = true;
    }
}
