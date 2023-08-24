using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBoat : MonoBehaviour
{
    [SerializeField] private GameObject playerCharacter;

    private ThirdPersonController playerController;

    [SerializeField] private TextMeshProUGUI speedButton;
    [SerializeField] private int speedPrice;
    [SerializeField] private TextMeshProUGUI magnetButton;
    [SerializeField] private int magnetPrice;

    [SerializeField] private int currentSpeedUpgrade = 0;
    [SerializeField] private int currentMagnetUpgrade = 0;
    [SerializeField] private int maxSpeedUpgrades = 5;
    [SerializeField] private int maxMagnetUpgrades = 5;

    [SerializeField] private Button speedUpgradeButton;
    [SerializeField] private Button magnetUpgradeButton;

    //public enum Upgrades { SPEED, SIZE};
    //public Upgrades upgrades;

    private void Start()
    {
        playerController = playerCharacter.GetComponent<ThirdPersonController>();

        speedButton.text = $"Speed ${speedPrice}";
        magnetButton.text = $"Magnets ${magnetPrice}";
    }

    private void Update()
    {
        if (MoneyManager.currentFunds < speedPrice)
        {
            speedButton.transform.parent.GetComponent<Button>().interactable = false;
        }

        if (MoneyManager.currentFunds < magnetPrice)
        {
            magnetButton.transform.parent.GetComponent<Button>().interactable = false;
        }

        if (MoneyManager.currentFunds >= speedPrice)
        {
            speedButton.transform.parent.GetComponent<Button>().interactable = true;
        }

        if (MoneyManager.currentFunds >= magnetPrice)
        {
            magnetButton.transform.parent.GetComponent<Button>().interactable = true;
        }
    }

    public void UpgradeBoatStats(int upgradeNumber)
    {
        if (upgradeNumber == 1)
        {
            if (currentSpeedUpgrade < maxSpeedUpgrades)
            {
                currentSpeedUpgrade++;
                UpgradeSpeed(speedPrice);
            }
            else
            {
                Debug.Log("reached max upgrade speed");
                speedButton.text = "SOLD OUT";
            }
        }
        if (upgradeNumber == 2)
        {
            if (currentMagnetUpgrade < maxSpeedUpgrades)
            {
                currentMagnetUpgrade++;
                UpgradeMagnet(magnetPrice);
            }
            else
            {
                magnetButton.text = "SOLD OUT";
            }
        }

        //switch (upgrades)
        //{
        //    case Upgrades.SPEED:
        //        UpgradeSpeed(speedPrice);
        //        break;
        //    case Upgrades.SIZE:
        //        UpgradeSize(sizePrice);
        //        break;
        //}
    }

    private void UpgradeSpeed(int price)
    {
        if (MoneyManager.SubtractMoney(price))
        {
            playerController.maxSpeed += 10;
            playerController.movementForce += 0.5f;
        }
        else
        {
            Debug.Log("Cannot Afford");
        }
    }
    private void UpgradeMagnet(int price)
    {
        if (MoneyManager.SubtractMoney(price))
        {
            MagentiseUpgrade magnetiseUpgrade = playerCharacter.GetComponent<MagentiseUpgrade>();
            magnetiseUpgrade.attractionForce += 5;
            magnetiseUpgrade.detectionRadius += 5;
        }
        else
        {
            Debug.Log("Cannot Afford");
        }
    }
    //private void UpgradeSize(int price)
    //{
    //    if (MoneyManager.SubtractMoney(price))
    //    {
    //        Vector3 boatScale = playerCharacter.transform.localScale;
    //        boatScale = new Vector3(boatScale.x * 1.1f, boatScale.y * 1.1f, boatScale.z * 1.1f);
    //        playerCharacter.transform.localScale = boatScale;
    //    }
    //    else
    //    {
    //        Debug.Log("Cannot Afford");
    //    }
    //}
}
