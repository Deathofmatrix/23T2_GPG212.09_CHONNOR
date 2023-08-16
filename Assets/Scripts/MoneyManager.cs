using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int startingFunds;

    public static int currentFunds;

    [SerializeField] private TextMeshProUGUI inventoryMoneyDisplay;

    [SerializeField] private int currentFundsTemp;

    private void Start()
    {
        currentFunds = startingFunds;
    }

    private void Update()
    {   
        currentFundsTemp = currentFunds;
        inventoryMoneyDisplay.text = $"${currentFunds}";
    }

    public static void AddMoney(int moneyToAdd)
    {
        currentFunds += moneyToAdd;
    }

    public static bool SubtractMoney(int moneyToSubtract)
    {
        if ((currentFunds - moneyToSubtract) < 0) return false;
        
        currentFunds -= moneyToSubtract;
        return true;
    }

}
