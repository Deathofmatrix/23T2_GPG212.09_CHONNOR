using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLocatorUpgrade : MonoBehaviour
{
    public delegate void ItemIndicatorUpgrade();
    public static event ItemIndicatorUpgrade OnItemIndicatorUpgrade;

    [SerializeField] private GameObject[] itemIndicators;

    //private bool areObjectsActive = false;
    

    void Start()
    {
        //foreach (GameObject indicator in itemIndicators)
        //{
        //    indicator.SetActive(true);
        //}

        OnItemIndicatorUpgrade?.Invoke();
    }

    //private void OnValidate()
    //{
    //    if (!areObjectsActive)
    //    {
    //        foreach (var item in itemIndicators) item.SetActive(true);
    //        areObjectsActive = true;
    //    }
    //}
}
