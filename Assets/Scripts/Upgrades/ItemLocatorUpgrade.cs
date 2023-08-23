using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLocatorUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject[] itemIndicators;
    

    void Start()
    {
        foreach (GameObject indicator in itemIndicators)
        {
            indicator.SetActive(true);
        }
    }
}
