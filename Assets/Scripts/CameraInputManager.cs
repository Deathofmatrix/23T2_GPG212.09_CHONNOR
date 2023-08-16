using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputManager : MonoBehaviour
{
    [SerializeField] private CinemachineInputProvider inputProvider;
    [SerializeField] private GameObject inventoryDisplay;
    [SerializeField] private GameObject ShopDisplay;

    void Update()
    {
        if (inventoryDisplay.activeInHierarchy || ShopDisplay.activeInHierarchy)
        {
            inputProvider.enabled = false;
        }
        else if (!inventoryDisplay.activeInHierarchy && !ShopDisplay.activeInHierarchy)
        {
            inputProvider.enabled = true;
        }
    }
}
