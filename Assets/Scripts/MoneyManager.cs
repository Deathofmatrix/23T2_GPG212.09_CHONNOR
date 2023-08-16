using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int startingFunds;

    public static int currentFunds;

    [SerializeField] private int currentFundsTemp;

    private void Start()
    {
        currentFunds = startingFunds;
    }

    private void Update()
    {   
        currentFundsTemp = currentFunds;
    }

    public static void AddMoney(int moneyToAdd)
    {
        currentFunds += moneyToAdd;
    }

    public static void SubtractMoney(int moneyToSubtract)
    {
        currentFunds -= moneyToSubtract;
    }

}
