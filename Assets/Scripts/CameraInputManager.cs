using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputManager : MonoBehaviour
{
    [SerializeField] private CinemachineInputProvider inputProvider;
    [SerializeField] private GameObject inventoryDisplay;
    [SerializeField] private GameObject ShopDisplay;
    [SerializeField] private GameObject UpgradeDisplay;
    [SerializeField] private GameObject QuestDisplay;

    void Update()
    {
        if (inventoryDisplay.activeInHierarchy || ShopDisplay.activeInHierarchy || UpgradeDisplay.activeInHierarchy || QuestDisplay.activeInHierarchy)
        {
            inputProvider.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else 
        {
            inputProvider.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
