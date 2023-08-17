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
    [SerializeField] private TextMeshProUGUI sizeButton;
    [SerializeField] private int sizePrice;

    //public enum Upgrades { SPEED, SIZE};
    //public Upgrades upgrades;

    private void Start()
    {
        playerController = playerCharacter.GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        speedButton.text = $"Speed ${speedPrice}";
        sizeButton.text = $"Big Boat ${sizePrice}";

        if (MoneyManager.currentFunds < speedPrice)
        {
            speedButton.transform.parent.GetComponent<Button>().interactable = false;
        }

        if (MoneyManager.currentFunds < sizePrice)
        {
            sizeButton.transform.parent.GetComponent<Button>().interactable = false;
        }

        if (MoneyManager.currentFunds >= speedPrice)
        {
            speedButton.transform.parent.GetComponent<Button>().interactable = true;
        }

        if (MoneyManager.currentFunds >= sizePrice)
        {
            sizeButton.transform.parent.GetComponent<Button>().interactable = true;
        }
    }

    public void UpgradeBoatStats(int upgradeNumber)
    {
        if (upgradeNumber == 1)
        {
            UpgradeSpeed(speedPrice);
        }
        if (upgradeNumber == 2)
        {
            UpgradeSize(sizePrice);
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
    private void UpgradeSize(int price)
    {
        if (MoneyManager.SubtractMoney(price))
        {
            Vector3 boatScale = playerCharacter.transform.localScale;
            boatScale = new Vector3(boatScale.x * 1.1f, boatScale.y * 1.1f, boatScale.z * 1.1f);
            playerCharacter.transform.localScale = boatScale;
        }
        else
        {
            Debug.Log("Cannot Afford");
        }
    }
}
