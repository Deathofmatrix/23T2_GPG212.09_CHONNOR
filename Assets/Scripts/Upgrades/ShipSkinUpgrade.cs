using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSkinUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject currentShipSkin;
    [SerializeField] private GameObject newShipSkin;

    void Start()
    {
        currentShipSkin.SetActive(false);
        newShipSkin.SetActive(true);
    }

}
